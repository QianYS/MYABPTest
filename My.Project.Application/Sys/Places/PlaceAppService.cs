using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using My.Project.Sys.Places.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places
{
    public class PlaceAppService : ApplicationService, IPlaceAppService
    {
        private readonly IRepository<Place, int> _placeRepository;
        private readonly PlaceManager _placeManager;
        public PlaceAppService(
            IRepository<Place, int> placeRepository,
            PlaceManager placeManager
            )
        {
            _placeRepository = placeRepository;
            _placeManager = placeManager;
        }

        /// <summary>
        /// 获取列表（首页） 第一级城市
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PlaceIndexOutput>> GetIndexList(GetIndexListInput input)
        {
            var getAll = _placeManager.GetAll();
            var query = _placeManager.GetAll()
                .WhereIf(((!string.IsNullOrWhiteSpace(input.Code)) && (input.IsParentOrSon)), p => p.ParentCode == input.Code)
                .WhereIf(((!string.IsNullOrWhiteSpace(input.Code)) && (!input.IsParentOrSon)), p => p.Code == input.Code);
            var x = query.ToList();
            var list = query.Select(p => new PlaceIndexOutput
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                ParentCode = p.ParentCode,
                Deep = p.Deep,
                ParentName = p.Deep == 1 ? "全国" : getAll.Where(z => z.Code == p.ParentCode).Select(z => z.Name).FirstOrDefault(),
                AdministerCount = getAll.Where(z => z.ParentCode == p.Code).Count(),
                GrandParentCode = getAll.Where(z => z.Code == p.ParentCode).Select(z => z.Code).FirstOrDefault(),
            })
            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), p => p.Name.Contains(input.Filter) || p.Code.Contains(input.Filter))
            .WhereIf(input.Deep.HasValue, p => p.Deep==input.Deep);
            var count = await list.CountAsync();
            var returnList = await list.OrderBy(p => p.Code).PageBy(input).ToListAsync();
            return new PagedResultDto<PlaceIndexOutput>(count, returnList);
        }
        
        /// <summary>
        /// 新建下辖城市或修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CreateChildOrEditOutput> GetForCreateChildOrEdit(GetPlacesForEditInput input)
        {
            CreateChildOrEditOutput outputDto = new CreateChildOrEditOutput();
            if (input.Code != null && input.Code != "")
            {
                Place place = _placeManager.GetByCode(input.Code);
                if (place != null)
                {
                    if (!input.CreateChildOrEdit)
                    {
                        outputDto.ParentId = place.Id;
                        outputDto.ParentName = place.Name;
                        outputDto.ParentCode = place.Code;
                    }
                    else
                    {
                        if (place.ParentCode.Trim() != "0")
                        {
                            Place parentPlace = _placeManager.GetByCode(place.ParentCode);
                            if (parentPlace != null)
                            {
                                outputDto.ParentId = parentPlace.Id;
                                outputDto.ParentName = parentPlace.Name;
                                outputDto.ParentCode = parentPlace.Code;
                            }
                            else
                            {
                                throw new UserFriendlyException("父级城市信息丢失！");
                            }
                        }
                        else
                        {
                            outputDto.ParentName = "全国";
                            outputDto.ParentCode = "0";
                        }
                        outputDto.Id = place.Id;
                        outputDto.Name = place.Name;
                        outputDto.Code = place.Code;
                    }
                }
                else
                {
                    throw new UserFriendlyException("城市信息丢失！");
                }
                return outputDto;
            }
            else
            {
                outputDto.ParentName = "全国";
                outputDto.ParentCode = "0";
                return outputDto;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public async Task Create(CreateOrUpdateInput input)
        {
            if (!_placeManager.GetAll().Any(p => p.Code == input.Code))
            {
                Place place = new Place();
                place.Name = input.Name;
                place.Code = input.Code;
                if (input.ParentId != 0)
                {
                    Place parentPlace = _placeManager.Get(input.ParentId);
                    if (parentPlace != null)
                    {
                        place.Deep = parentPlace.Deep + 1;
                        place.ParentCode = parentPlace.Code;
                    }
                    else
                    {
                        throw new UserFriendlyException("父级城市信息丢失！");
                    }
                }
                else
                {
                    place.Deep = 1;
                    place.ParentCode = "0";
                }
                await _placeRepository.InsertAsync(place);
            }
            else
            {
                throw new UserFriendlyException("城市编号已使用！");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public async Task Update(CreateOrUpdateInput input)
        {
            Place place = _placeManager.Get(input.Id);
            if (place != null)
            {
                if (input.Code != place.Code)
                {
                    var query = _placeManager.GetSonByCode(place.Code);
                    List<Place> placeList = query.ToList();
                    foreach(var item in placeList)
                    {
                        item.Code = input.Code;
                    }
                }
                else
                {
                    place.Name = input.Name;
                    //await _placeRepository.UpdateAsync(place);
                }
            }
            else
            {
                throw new UserFriendlyException("城市信息丢失！");
            }
        }
    }
}
