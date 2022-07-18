using Autofac;
using DoctorAppointment.Application.UseCases.V1_0;
using SharedKernal.Middlewares.Basees;
using System;
using System.Collections.Generic;
using System.Linq;
using _UseCases = DoctorAppointment.Application.Interfases.UseCases;

namespace DoctorAppointment.Infrastructure.DependencyResolution
{
    internal class ServiceModule : Module
    {
        internal static void Initialize(ContainerBuilder container)
        {
            ResolveService(container);
        }

        private static void ResolveService(ContainerBuilder builder)
        {
            var service = typeof(InsertSampleUseCase);
            Type[] services = System.Reflection.Assembly.Load(service.Assembly.GetName()).GetTypes().Where(x => string.Equals(x.Namespace, service.Namespace, StringComparison.Ordinal) && x.IsSubclassOf(typeof(BaseUseCase))).ToArray();

            var iService = typeof(_UseCases.V1_0.IInsertSampleUseCase);
            List<Type> iServices = System.Reflection.Assembly.Load(iService.Assembly.GetName()).GetTypes().Where(a => string.Equals(a.Namespace, iService.Namespace, StringComparison.Ordinal) && a.IsInterface).ToList();

            //var iServiceV2_0 = typeof(_UseCases.V2_0.IInsertSampleUseCase);
            //iServices.AddRange(System.Reflection.Assembly.Load(iServiceV2_0.Assembly.GetName()).GetTypes().Where(a => string.Equals(a.Namespace, iServiceV2_0.Namespace, StringComparison.Ordinal) && a.IsInterface).ToList());


            Resolve(builder, services, iServices.ToArray());
        }

        private static void Resolve(ContainerBuilder builder, Type[] service, Type[] iService)
        {
            foreach (Type serviceInterface in iService)
            {
                Type classType = service.FirstOrDefault(x => serviceInterface.IsAssignableFrom(x));
                if (classType != null)
                {
                    builder.RegisterType(classType).As(serviceInterface).PropertiesAutowired().InstancePerLifetimeScope();
                }
            }
        }
    }
}