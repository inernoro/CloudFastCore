using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.ApiManager.CodeBuild;
using Cloud.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Areas.ApiManager.Controllers
{
    [Area("ApiManager")]
    public class ManagerController : CloudControllerBase
    {
        private readonly ICodeBuildAppService _codeBuildAppService;

        public ManagerController(ICodeBuildAppService codeBuildAppService)
        {
            _codeBuildAppService = codeBuildAppService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public FileResult GetResult(string tableName)
        {
            var result = _codeBuildAppService.BuilDictionary(tableName);
            foreach (var node in result)
            {
                var data = Encoding.UTF8.GetBytes(node.Value);
                return File(data, "text/plain", node.Key);
            }
            return null;
        } 
    }
}