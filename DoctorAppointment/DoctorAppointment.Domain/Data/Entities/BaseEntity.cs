using SharedKernal.Data;
using System;
using System.Collections.ObjectModel;

namespace DoctorAppointment.Domain.Data
{
    public abstract class BaseEntity<TPrimaryKey> :IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
     
        public DateTime DateCreated { get; set; }
      
    }
}
