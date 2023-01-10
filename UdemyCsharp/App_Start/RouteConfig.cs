using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UdemyCsharp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //attribute routing
            routes.MapMvcAttributeRoutes();

            //Convention based routing - not much use now. instead of this we can use attribute routing , it's easy
            //routes.MapRoute(
            //     "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new {controller="Movies", action="ByReleaseDate"},
            //    new {year= @"2015|2016", month=@"\d{2}"} //\d = digit {4}=4 repetition
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
