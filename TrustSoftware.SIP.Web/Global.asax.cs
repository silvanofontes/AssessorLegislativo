using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.Http;
using SilvanoFontes.AL.Web.Controllers;

namespace SilvanoFontes.AL.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //  RouteTable.Routes.MapHttpRoute (
            //      name: "DefaultApi" ,
            //      routeTemplate: "api / {controller} / {id}" ,
            //      defaults: new {id = RouteParameter.Optional});

            //  RouteTable.Routes.MapHttpRoute(
            //        name: "GetUsuario",
            //        routeTemplate: "api/{controller}/{action}/{id}",
            //        defaults: new { id = RouteParameter.Optional }

            //    );
            //  RouteTable.Routes.MapHttpRoute(
            //        name: "GetAll",
            //        routeTemplate: "api/{controller}/{action}"
            //    );

            Rotas.RegisterRoutes(RouteTable.Routes);

        }



        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


    }
}