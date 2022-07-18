using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Domain.Interfases.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Domain.Repositories.Dapper
{
    public class DapperSampleRepository : DapperBaseRepository<SampleEntity, Guid>, IDapperSampleRepository
    {
        public DapperSampleRepository()
        {
        }
    }
}
