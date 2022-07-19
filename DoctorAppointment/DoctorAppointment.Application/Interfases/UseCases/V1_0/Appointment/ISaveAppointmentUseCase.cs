using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Application.DTOs.OutputDTOs;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Application.Interfases.UseCases.V1_0
{
    public interface ISaveAppointmentUseCase : IBaseUseCase<AppointmentInputDTO,bool>
    {
    }
}
