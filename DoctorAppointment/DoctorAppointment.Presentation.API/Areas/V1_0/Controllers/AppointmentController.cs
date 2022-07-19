using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Application.DTOs.OutputDTOs;
using DoctorAppointment.Application.Interfases.UseCases.V1_0;
using DoctorAppointment.Presentation.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Presentation.API.Areas.V1_0.Controllers
{
    [ApiVersion(version: APIVersion.Version1)]
    public class AppointmentController : BaseController
    {
        [HttpGet]
        [MapToApiVersion(version: APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AppointmentOutputDTO>))]
        public async Task<IActionResult> GetAppointments([FromServices] IGetAppointmentsUseCase getAppointmentsUseCase, DateTime date) =>
              await Presenter.Handle(getAppointmentsUseCase.Handle, new BaseRequestDto<DateTime> { Data = date });

        [HttpPost]
        [MapToApiVersion(version: APIVersion.Version1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResultDto<bool>))]
        public async Task<IActionResult> SaveAppointment([FromServices] ISaveAppointmentUseCase SaveAppointmentUseCase, BaseRequestDto<AppointmentInputDTO> appointmentInputDTO) =>
             await Presenter.Handle(SaveAppointmentUseCase.Handle, appointmentInputDTO);
    }

}
