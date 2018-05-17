using System.Threading.Tasks;
using Abp.Application.Services;
using My.Project.Configuration.Dto;

namespace My.Project.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}