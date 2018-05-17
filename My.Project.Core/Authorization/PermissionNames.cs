namespace My.Project.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";

        public const string Pages_Users = "Pages.Users";

        public const string Pages_Roles = "Pages.Roles";

        public const string Pages = "Pages";

        #region 系统管理
        public const string Pages_Sys = Pages + ".Sys";

        #region 地区管理
        public const string Pages_Sys_Places = Pages_Sys + ".Places";//列表页
        public const string Pages_Sys_Places_CreateOrEdit = Pages_Sys_Places + ".CreateOrEdit";//新增修改权限
        public const string Pages_Sys_Places_Delete = Pages_Sys_Places + ".Delete";//新增修改权限
        #endregion
        #endregion
    }
}