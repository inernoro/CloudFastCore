using Cloud.UserInfoApp;
using Cloud.UserInfoApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Controllers
{
    public class HomeController : CloudControllerBase
    {
        private readonly IUserInfoAppService _userInfoAppService;

        public HomeController(IUserInfoAppService userInfoAppService)
        {
            _userInfoAppService = userInfoAppService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public string Post([FromBody] Users user)
        {
          //  _userInfoAppService.Post(postInput);
            return "OK";
        }
    }

    public class Users
    {
        public string Name { get; set; }
    }
}