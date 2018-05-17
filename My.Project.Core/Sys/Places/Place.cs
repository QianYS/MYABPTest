using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places
{
    [Table("SysPlaces")]
    public class Place : Entity<int>
    {
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
