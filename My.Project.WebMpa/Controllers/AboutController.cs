using System.Web.Mvc;

namespace My.Project.WebMpa.Controllers
{
    public class AboutController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}