using SharedKernal.Data;
using System;
using System.Collections.ObjectModel;

namespace DoctorAppointment.Domain.Data
{
    public abstract class BaseEntity<TPrimaryKey> : ValueObject, IEntity<TPrimaryKey>, ICreationSignature<int>, IModificationSignature<int?>
    {
        public TPrimaryKey Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
