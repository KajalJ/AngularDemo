using System;
using System.Web.Http;

namespace AngularDemo
{
    internal class WebApiConfig
    {
        internal static void Register(HttpConfiguration obj)
        {

            // Web API routes
            obj.MapHttpAttributeRoutes();

            obj.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}