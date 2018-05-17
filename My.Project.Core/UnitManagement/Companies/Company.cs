using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Project.UnitManagement.Companies
{
    public class Company: FullAuditedEntity<Guid>
    {
        public string DisplayName { get; set; }
    }
}
