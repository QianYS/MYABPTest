using System.Collections.Generic;
using My.Project.Roles.Dto;
using My.Project.Users.Dto;

namespace My.Project.WebMpa.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}