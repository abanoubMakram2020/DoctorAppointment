using DoctorAppointment.Domain.Data.Entities;
using SharedKernal.DataRepositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Interfases.Repositories.Dapper
{
    public interface IDapperSampleRepository : IDapperBaseRepository<SampleEntity, Guid>
    {
    }
}
