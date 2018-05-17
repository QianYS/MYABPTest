using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace My.Project.WebMpa.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}