using Abp.Authorization;
using My.Project.Authorization.Roles;
using My.Project.Authorization.Users;

namespace My.Project.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
