using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Tzoker.Results.Lib;
using System.Web.Http.Description;
using Tzoker.Results.CustomHandlers;

namespace Tzoker.Results
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;
            config.Services.Replace(typeof(IDocumentationProvider), new XmlCommentDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/Tzoker.Results.XML")));
            GlobalConfiguration.Configuration.MessageHandlers.Add(new MongoCacheHandler());
        }
    }
}