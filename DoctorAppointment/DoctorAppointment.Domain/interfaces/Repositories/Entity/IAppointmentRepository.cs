using DoctorAppointment.Domain.Data.Entities;
using SharedKernal.DataRepositories;

namespace DoctorAppointment.Domain.interfaces.Repositories.Entity
{
    public interface IAppointmentRepository : IBaseRepository<Appointment, int>
    {
    }
}
