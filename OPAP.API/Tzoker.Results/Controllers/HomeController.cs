using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Tzoker.Results.Models;

namespace Tzoker.Results.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return View(new ApiModel(explorer));
        }
    }
}
