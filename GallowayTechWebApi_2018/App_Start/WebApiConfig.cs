using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GallowayTechWebApi_2018
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

#if DEBUG
            // Cross Origin Requests - site wide
            var cors = new EnableCorsAttribute("http://localhost:7777", "*", "*");
            config.EnableCors(cors);
#endif

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
