using System.Threading.Tasks;
using Abp.Application.Services;
using My.Project.Authorization.Accounts.Dto;

namespace My.Project.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
