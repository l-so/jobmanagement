using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace JobManagement.WebMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "JobManagement.WebMvc.Controllers" }
            );
            routes.MapRoute(
                name: "DisplayDocs",
                url: "{controller}/{type}/{id}/{p1}/{p2}/{p3}",
                defaults: new { controller = "DisplayDocument", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional, p1 = UrlParameter.Optional, p2 = UrlParameter.Optional, p3 = UrlParameter.Optional },
                namespaces: new string[] { "JobManagement.WebMvc.Controllers" }
            );

        }
    }
}
