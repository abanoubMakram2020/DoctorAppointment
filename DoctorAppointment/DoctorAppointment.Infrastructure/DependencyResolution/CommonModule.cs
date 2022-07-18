using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using SharedKernal.Middlewares.Basees;
using SharedKernal.Middlewares.Handler;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.Logging;
using SharedKernal.Middlewares.MemoryCache;
using SharedKernal.Middlewares.ResourcesReader.Message;

namespace DoctorAppointment.Infrastructure.DependencyResolution
{
    internal class CommonModule : Module
    {
        internal static void Initialize(ContainerBuilder container)
        {
            container.RegisterType<MessageResourceReader>().As<IMessageResourceReader>().PropertiesAutowired().InstancePerLifetimeScope();
            container.RegisterType<MemoryCacheService>().As<IMemoryCacheService>().PropertiesAutowired().InstancePerLifetimeScope();
            container.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            container.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().PropertiesAutowired().SingleInstance();
            container.RegisterType<CommonHandle>().As<ICommonHandle>().PropertiesAutowired().InstancePerLifetimeScope();
            container.RegisterType<TokenHandler>().As<ITokenHandler>().SingleInstance();
            container.RegisterType<Presenter>().SingleInstance();
            container.RegisterType<Logger>().As<ILogger>();
            //container.RegisterType<ServiceEmployeeExtentions>().PropertiesAutowired().InstancePerLifetimeScope();           
            //container.RegisterType<HttpRequest>().As<IHttpRequest>().InstancePerLifetimeScope();
        }
    }
}