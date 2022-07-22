using Autofac;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;

using DoctorAppointment.Domain.Repositories.Entity;

namespace DoctorAppointment.Infrastructure.DependencyResolution
{
    internal class RepositoryModule : Module
    {
        internal static void Initialize(ContainerBuilder container)
        {
            ResolveEntityRepositories(container);
        }

        private static void ResolveEntityRepositories(ContainerBuilder builder)
        {
            var repository = typeof(AppointmentRepository);
            var iRepository = typeof(IAppointmentRepository);
            Type[] repositories = System.Reflection.Assembly.Load(repository.Assembly.GetName()).GetTypes().Where(x => string.Equals(x.Namespace, repository.Namespace, StringComparison.Ordinal) /*&& x.IsSubclassOf(typeof(EntityBaseRepository<,>))*/).ToArray();
            Type[] iRepositories = System.Reflection.Assembly.Load(iRepository.Assembly.GetName()).GetTypes().Where(a => string.Equals(a.Namespace, iRepository.Namespace, StringComparison.Ordinal) && a.IsInterface).ToArray();
            Resolve(builder, repositories, iRepositories);
        }

       

        private static void Resolve(ContainerBuilder builder, Type[] repository, Type[] irepository)
        {
            foreach (Type repo in irepository)
            {
                Type classType = repository.FirstOrDefault(x => repo.IsAssignableFrom(x));
                if (classType != null)
                {
                    builder.RegisterType(classType).As(repo).PropertiesAutowired().InstancePerLifetimeScope();
                }
            }
        }
    }
}