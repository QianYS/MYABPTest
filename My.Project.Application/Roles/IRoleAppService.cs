using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using My.Project.Roles.Dto;

namespace My.Project.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<RoleListDto>> GetRoles(GetRolesInput input);
        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input);

        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
