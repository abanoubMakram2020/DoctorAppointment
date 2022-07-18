using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.DTOs.OutputDTOs
{
    public record IdNameOutputDTO<TKey, TValue> : BaseOutputDTO
    {
        public TKey Id { get; }
        public TValue Name { get; }

        public IdNameOutputDTO(TKey id, TValue name)
        {
            Id = id;
            Name = name;
        }
    }

    public record IdNameOutputDTO<TKey, TValue, TType> : IdNameOutputDTO<TKey, TValue>
    {
        public TType Type { get; }
        public IdNameOutputDTO(TKey id, TValue name, TType type)
            : base(id, name)
        {
            Type = type;
        }
    }
}
