using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Infrastructure.Language;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("MainPage", "id{id}", new {controller = "Home", action = "Index"});

            routes.MapRoute(
                name: "Default", //Route name
                url: "{controller}/{action}/{id}", //URL with psrsmetrs
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //Parametr default
            );
        }
    }
}
