using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using My.Project.Roles.Dto;
using My.Project.Users.Dto;

namespace My.Project.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}