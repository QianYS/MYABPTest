using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    public class PlaceIndexOutput : EntityDto<int>
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 地区名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 父名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 上上级编号
        /// </summary>
        public string GrandParentCode { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Deep { get; set; }
        /// <summary>
        /// 下辖数量
        /// </summary>
        public int AdministerCount { get; set; }
        /// <summary>
        /// 上级城市
        /// </summary>
        //[JsonIgnore]
        //public Place ParentPlace { get; set; }
        //public PlaceDto ParentPlaceDto { get { if (ParentPlace != null) { return ParentPlace.MapTo<PlaceDto>(); } else { return null; } } }
    }
}
