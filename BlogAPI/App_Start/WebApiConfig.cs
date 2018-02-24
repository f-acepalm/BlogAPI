using BlogAPI.Filters;
using Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace BlogAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new KeyNotFoundExceptionFilterAttribute());
            config.Filters.Add(new ArgumentNullExceptionFilterAttribute());

            config.DependencyResolver = new UnityResolver(UnityContainerConfiguration.GetContainer());
            AutoMapperInitializer.Initialize();
        }
    }
}
