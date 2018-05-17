using System.Collections.Generic;
using My.Project.Roles.Dto;

namespace My.Project.WebMpa.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}