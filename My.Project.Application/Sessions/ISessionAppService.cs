using System.Threading.Tasks;
using Abp.Application.Services;
using My.Project.Sessions.Dto;

namespace My.Project.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
