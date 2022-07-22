using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Application.Interfases.UseCases.V1_0;
using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using FluentValidation;
using SharedKernal.Common.Enum;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Application.UseCases.V1_0
{
    public class SaveAppointmentUseCase : BaseUseCase, ISaveAppointmentUseCase
    {
        public IAppointmentRepository AppointmentRepository { get; set; }
        public IValidator<AppointmentInputDTO> Validator { get; set; }
        public async Task<ResponseResultDto<bool>> Handle(BaseRequestDto<AppointmentInputDTO> model)
        {
            
            var result = Validator.Validate(model.Data);
            if (!result.IsValid)
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                result.Errors.GroupBy(p => p.PropertyName).ToList().ForEach(item => dict.Add(item.Key, item.Distinct().Select(e => e.ErrorMessage).ToList()));
                return ResponseResultDto<bool>.MultiError(dic: dict, message: MessageResource.GetMessage(ResponseStatusCode.InvalidData));
            }

            var appointment_DB = await AppointmentRepository.Get(model.Data.Id);

            if (appointment_DB is null)
            {
                var appointment = Mapper.Map<AppointmentInputDTO, Appointment>(model.Data);
                await AppointmentRepository.Insert(entity: appointment);
            }
            else
            {
                var appointment = Mapper.Map(model.Data, appointment_DB);
                AppointmentRepository.Update(entity: appointment);
            }
            await UnitOfWork.Commit();

            return ResponseResultDto<bool>.Success(result: true, message: MessageResource.GetMessage(ResponseStatusCode.Successfully));
        }
    }
}
