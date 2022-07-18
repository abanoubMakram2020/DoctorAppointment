using Autofac;

namespace DoctorAppointment.Infrastructure.DependencyResolution
{
    public static class DependencyResolutionFacade
    {
        public static void Initialize(ContainerBuilder container)
        {
            DataModule.Initialize(container);
            CommonModule.Initialize(container);
            RepositoryModule.Initialize(container);
            ServiceModule.Initialize(container);
        }
    }
}