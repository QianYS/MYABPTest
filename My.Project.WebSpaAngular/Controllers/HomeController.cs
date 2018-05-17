using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace My.Project.WebSpaAngular.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}