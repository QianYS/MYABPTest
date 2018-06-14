using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    public class CreateChildOrEditOutput
    {
        public int ParentId { get; set; } = 0;

        public string ParentCode { get; set; }

        public string ParentName { get; set; }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
