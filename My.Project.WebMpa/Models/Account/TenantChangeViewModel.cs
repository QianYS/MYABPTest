using Abp.AutoMapper;
using My.Project.Sessions.Dto;

namespace My.Project.WebMpa.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}