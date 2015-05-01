using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SilvanoFontes.AL.Web.Controllers
{
    public static class Rotas
    {

        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute("action",
                "api/{controller}/{action}/{*parameter}",
                "~/Controllers/WebControllers.aspx");

        }

    }
}