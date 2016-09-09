using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Controllers
{
    public class HomeController : CloudControllerBase
    {
        public ActionResult Index()
        {
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}