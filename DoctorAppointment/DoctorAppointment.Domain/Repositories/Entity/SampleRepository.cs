using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Domain.Interfases.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using System;


namespace DoctorAppointment.Domain.Repositories.Entity
{
    public class SampleRepository : EntityBaseRepository<SampleEntity, Guid>, ISampleRepository
    {
        public SampleRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
