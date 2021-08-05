using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHup2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var settings= GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
            //    settings.ContractResolver
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
