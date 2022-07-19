using DoctorAppointment.Application.DTOs.OutputDTOs;
using DoctorAppointment.Application.Interfases.UseCases.V1_0;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using SharedKernal.Common.Enum;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Application.UseCases.V1_0
{
    public class GetAppointmentsUseCase : BaseUseCase, IGetAppointmentsUseCase
    {
        public IAppointmentRepository AppointmentRepository { get; set; }
        public async Task<ResponseResultDto<List<AppointmentOutputDTO>>> Handle(BaseRequestDto<DateTime> model)
        {
            if (model.Data == default)
            {
                var all_Appointments_DB = await AppointmentRepository.Get().ToListAsync();
                if (!all_Appointments_DB.Any())
                    return ResponseResultDto<List<AppointmentOutputDTO>>.NotFound(result: null, message: MessageResource.GetMessage(ResponseStatusCode.NotFound));

                return ResponseResultDto<List<AppointmentOutputDTO>>.Success(result: Mapper.Map<List<AppointmentOutputDTO>>(all_Appointments_DB), message: MessageResource.GetMessage(ResponseStatusCode.NotFound));
            }
            var appointments_DB = await AppointmentRepository.Get(x => x.AppointmentDate.Date == Convert.ToDateTime(model.Data).Date).ToListAsync();

            if (!appointments_DB.Any())
                return ResponseResultDto<List<AppointmentOutputDTO>>.NotFound(result: null, message: MessageResource.GetMessage(ResponseStatusCode.NotFound));

            return ResponseResultDto<List<AppointmentOutputDTO>>.Success(result: Mapper.Map<List<AppointmentOutputDTO>>(appointments_DB), message: MessageResource.GetMessage(ResponseStatusCode.NotFound));
        }
    }
}
