using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    public class GetIndexListInput: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public int? Deep { get; set; } = 1;
        public string Code { get; set; }
        public bool IsParentOrSon { get; set; }
    }
}
