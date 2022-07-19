using DoctorAppointment.Application.DTOs.OutputDTOs;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Application.Interfases.UseCases.V1_0
{
    public interface IGetAppointmentsUseCase : IBaseUseCase<IEnumerable<AppointmentOutputDTO>>
    {
    }
}
