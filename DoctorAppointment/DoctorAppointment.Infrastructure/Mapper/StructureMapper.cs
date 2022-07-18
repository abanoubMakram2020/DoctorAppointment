using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.Mapper
{
    internal class StructureMapper : Profile
    {
        public StructureMapper()
        {
            Initialize();
        }

        public void Initialize()
        {
            //CreateMap<LookupValue, LookupValueInputDTO>().ReverseMap();
        }
    }
}
