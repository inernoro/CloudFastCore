using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Controllers
{
    public class TestController : CloudControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}