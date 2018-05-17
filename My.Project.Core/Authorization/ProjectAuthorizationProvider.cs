using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace My.Project.Authorization
{
    public class ProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("全部"));
            }

            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            #region 系统管理
            {
                // 系统管理
                var pages_Sys = pages.CreateChildPermission(PermissionNames.Pages_Sys, L("系统管理"));
                #region 地区管理
                {
                    var pages_Sys_Places = pages_Sys.CreateChildPermission(PermissionNames.Pages_Sys_Places, L("地区管理"));
                    var pages_Sys_Places_CreateOrEdit = pages_Sys.CreateChildPermission(PermissionNames.Pages_Sys_Places_CreateOrEdit, L("新增/修改"));
                    var pages_Sys_Places_Delete = pages_Sys.CreateChildPermission(PermissionNames.Pages_Sys_Places_Delete, L("删除"));
                }
                #endregion
                
            }
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ProjectConsts.LocalizationSourceName);
        }
    }
}
