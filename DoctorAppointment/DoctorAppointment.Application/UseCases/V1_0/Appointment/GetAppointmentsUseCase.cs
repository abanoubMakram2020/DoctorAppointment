using DoctorAppointment.Application.DTOs.OutputDTOs;
using DoctorAppointment.Application.Interfases.UseCases.V1_0;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Application.UseCases.V1_0
{
    public class GetAppointmentsUseCase : BaseUseCase, IGetAppointmentsUseCase
    {
        public IAppointmentRepository AppointmentRepository { get; set; }
        public async  Task<ResponseResultDto<IEnumerable<AppointmentOutputDTO>>> Handle()
        {
            throw new NotImplementedException();
        }
    }
}
