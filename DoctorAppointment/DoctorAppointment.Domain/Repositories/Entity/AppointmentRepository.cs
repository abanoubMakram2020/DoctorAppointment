using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Domain.Repositories.Entity
{
    public class AppointmentRepository : EntityBaseRepository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
