using Abp.Application.Navigation;
using Abp.Localization;
using My.Project.Authorization;

namespace My.Project.WebSpaAngular
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class ProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu.AddItem(new MenuItemDefinition(
                "home",
                new FixedLocalizableString("首页"),
                url: "/",
                icon: "fa fa-home"
                ));
            context.Manager.MainMenu.AddItem(new MenuItemDefinition(
                "Sys",
                new LocalizableString("HomePage", ProjectConsts.LocalizationSourceName),
                url: null,
                icon: "fa fa-home"
                //requiresAuthentication: true
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        new FixedLocalizableString("租户管理"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        new FixedLocalizableString("用户管理"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Roles",
                        new FixedLocalizableString("角色管理"),
                        url: "#roles",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Roles
                     )
                ).AddItem(
                     new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", ProjectConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                    )
                )
            );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ProjectConsts.LocalizationSourceName);
        }
    }
}
