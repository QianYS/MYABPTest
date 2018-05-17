using Abp.Web.Mvc.Views;

namespace My.Project.WebSpaAngular.Views
{
    public abstract class ProjectWebViewPageBase : ProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class ProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ProjectWebViewPageBase()
        {
            LocalizationSourceName = ProjectConsts.LocalizationSourceName;
        }
    }
}