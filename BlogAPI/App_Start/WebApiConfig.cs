using BlogAPI.Filters;
using Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Filters;

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

            config.Filters.AddRange(GetFilters());

            config.DependencyResolver = new UnityResolver(UnityContainerConfiguration.GetContainer());
            AutoMapperInitializer.Initialize();
        }

        private static IEnumerable<IFilter> GetFilters()
        {
            return new IFilter[]
            {
                new KeyNotFoundExceptionFilterAttribute(),
                new ArgumentNullExceptionFilterAttribute(),
            };
        }
    }
}
