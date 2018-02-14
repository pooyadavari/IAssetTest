using Autofac;
using Autofac.Integration.WebApi;
using IassetBackend.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace IassetBackend
{
    public class IocConfig
    {
        public static void Configure()
        {
            // Autofac configurations
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<WeatherRepository>().As<IWeatherRepository>().InstancePerRequest();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}