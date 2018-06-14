using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.Sys.Places.Dto
{
    public class GetPlacesForEditInput
    {
        public string Code { get; set; }
        public bool CreateChildOrEdit { get; set; }
    }
}
