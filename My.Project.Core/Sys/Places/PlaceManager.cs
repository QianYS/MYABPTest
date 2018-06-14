using Abp.Domain.Repositories;
using Abp.Domain.Services;
using My.Project.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places
{
    public class PlaceManager: DomainService
    {
        private readonly IRepository<Place, int> _placeRepository;

        public PlaceManager(
            IRepository<Place, int> placeRepository
            )
        {
            _placeRepository = placeRepository;
        }
        /// <summary>
        /// 获取全部（无条件）
        /// </summary>
        /// <returns></returns>
        public IQueryable<Place> GetAll()
        {
            return _placeRepository.GetAll();
        }
        /// <summary>
        /// 获取全部（有权限）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IQueryable GetAll(User user)
        {
            return _placeRepository.GetAll();
        }

        /// <summary>
        /// 获取一个实体通过Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Place Get(int id)
        {
            return _placeRepository.Get(id);
        }

        /// <summary>
        /// 获取一个实体通过Code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Place GetByCode(string code)
        {
            return _placeRepository.GetAll().Where(p => p.Code == code).FirstOrDefault();
        }

        /// <summary>
        /// 获取一个实体通过Code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Place> GetSonByCode(string code)
        {
            return _placeRepository.GetAll().Where(p => p.ParentCode == code);
        }
    }
}
