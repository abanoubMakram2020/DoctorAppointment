using DoctorAppointment.Domain.Data.Entities;
using SharedKernal.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfases.Repositories.Entity
{
    public interface ISampleRepository : IBaseRepository<SampleEntity, Guid>
    {
    }
}
