using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    [AutoMap(typeof(Place))]
    public class PlaceDto: EntityDto<int>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 地区名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ParentCode { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public int Deep { get; set; }
    }
}
