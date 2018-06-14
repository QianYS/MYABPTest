using Abp.Application.Services;
using Abp.Application.Services.Dto;
using My.Project.Sys.Places.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places
{
    public interface IPlaceAppService : IApplicationService
    {
        /// <summary>
        /// 获取列表（首页）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PlaceIndexOutput>> GetIndexList(GetIndexListInput input);

        /// <summary>
        /// 新建下辖城市 或 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CreateChildOrEditOutput> GetForCreateChildOrEdit(GetPlacesForEditInput input);

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        Task Create(CreateOrUpdateInput input);

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        Task Update(CreateOrUpdateInput input);
    }
}
