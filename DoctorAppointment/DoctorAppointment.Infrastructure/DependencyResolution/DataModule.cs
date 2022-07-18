using Autofac;
using DoctorAppointment.Infrastructure.SQLContext;
using Microsoft.EntityFrameworkCore;
using SharedKernal.DataRepositories;
using SharedKernal.EntityFramework;

namespace DoctorAppointment.Infrastructure.DependencyResolution
{
    internal class DataModule : Module
    {
        internal static void Initialize(ContainerBuilder container)
        {
            container.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();
        }
    }
}