using Abp.Application.Services;
using Abp.Application.Services.Dto;
using My.Project.MultiTenancy.Dto;

namespace My.Project.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
