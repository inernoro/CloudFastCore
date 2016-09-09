using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Controllers
{
    public class HomeController : CloudControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}