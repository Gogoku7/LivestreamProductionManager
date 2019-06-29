using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LivestreamProductionManager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SuperSmashBros",
                url: "{controller}/{action}/{series}/{game}/{format}",
                defaults: new { controller = "SuperSmashBros", action = "GetManageCompetitors" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FightingGames", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
