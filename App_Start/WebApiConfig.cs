using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.App_Start
{
    using System.Web.Http;
    using Unity;
    using WebApplication8.api;

    class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
            // Web API routes
            config.MapHttpAttributeRoutes();
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            UnityConfig.RegisterComponents();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
            

        }
    }
}