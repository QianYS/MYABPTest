using Abp.Web.Mvc.Views;

namespace My.Project.WebMpa.Views
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