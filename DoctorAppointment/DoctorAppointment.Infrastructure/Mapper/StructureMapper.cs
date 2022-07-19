using AutoMapper;
using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Application.DTOs.OutputDTOs;
using DoctorAppointment.Domain.Data.Entities;

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
            CreateMap<Appointment, AppointmentInputDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentOutputDTO>().ReverseMap();
        }
    }
}
