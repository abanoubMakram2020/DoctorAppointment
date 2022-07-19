
using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using FluentValidation;
using SharedKernal.Middlewares.ResourcesReader;
using SharedKernal.Middlewares.ResourcesReader.Message;

namespace DoctorAppointment.Application.Validations
{
    public class AppointmentInputValidation : AbstractValidator<AppointmentInputDTO>
    {
        private const string PHONE_NUMBER_REGULAR_EXPRESSSION = @"[0 - 9]{11}";
        private readonly IMessageResourceReader _messageResource;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentInputValidation(IMessageResourceReader messageResource, IAppointmentRepository appointmentRepository)
        {
            _messageResource = messageResource;
            _appointmentRepository = appointmentRepository;
            IsValid();
        }
        void IsValid()
        {
            RuleFor(x => x.PatientName).Must((patientName) => { return CheckPatientName(patientName); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.PatientNameRequired));

            RuleFor(x => x.PatientPhoneNumber).Must((patientPhoneNumber) => { return CheckPatientPhoneNumber(patientPhoneNumber); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.PatientPhoneNumberRequired))
                          .Matches(PHONE_NUMBER_REGULAR_EXPRESSSION)
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.InvalidMobileNumber));

            RuleFor(x => x.AppointmentDate).Must((appointmentDate) => { return CheckAppointmentDate(appointmentDate); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.AppointmentDateRequired));

            RuleFor(x => x.AppointmentTimeFrom).Must((appointmentTimeFrom) => { return CheckAppointmentTimeFrom(appointmentTimeFrom); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.AppointmentTimeFromRequired));

            RuleFor(x => x.AppointmentTimeTo).Must((appointmentTimeTo) => { return CheckAppointmentTimeTo(appointmentTimeTo); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.AppointmentTimeToRequired));
        }

        bool CheckPatientName(string? patientName) =>
            (!string.IsNullOrWhiteSpace(patientName) && patientName.Length > 0 && patientName.Length < 64);

        bool CheckPatientPhoneNumber(string? patientPhoneNumber) =>
             (!string.IsNullOrWhiteSpace(patientPhoneNumber) && patientPhoneNumber.Length == 11);

        bool CheckAppointmentDate(DateTime? appointmentDate) =>
             (appointmentDate.HasValue && appointmentDate > default(DateTime) && appointmentDate >= DateTime.Now);

        bool CheckAppointmentTimeTo(TimeSpan? appointmentTimeTo) =>
            (appointmentTimeTo.HasValue && appointmentTimeTo > default(TimeSpan));

        bool CheckAppointmentTimeFrom(TimeSpan? appointmentTimeFrom) =>
             (appointmentTimeFrom.HasValue && appointmentTimeFrom > default(TimeSpan));
    }
}
