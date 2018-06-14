using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    public class GetChildListInput: PagedAndSortedResultRequestDto
    {
        public string Code { get; set; }
    }
}
