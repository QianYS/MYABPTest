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

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<RoleDto> Create(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<RoleDto> Update(CreateOrUpdateRoleInput input);
    }
}
