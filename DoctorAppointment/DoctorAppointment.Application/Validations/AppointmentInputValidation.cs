
using DoctorAppointment.Application.DTOs.InputDTOs;
using DoctorAppointment.Domain.interfaces.Repositories.Entity;
using FluentValidation;
using SharedKernal.Middlewares.ResourcesReader;
using SharedKernal.Middlewares.ResourcesReader.Message;
using System.Text.RegularExpressions;

namespace DoctorAppointment.Application.Validations
{
    public class AppointmentInputValidation : AbstractValidator<AppointmentInputDTO>
    {
        private const string PHONE_NUMBER_REGULAR_EXPRESSSION = @"^01[0125][0-9]{8}$";
        private const string TIME_SPAN_REGULAR_EXPRESSSION = @"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)";
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

            RuleFor(x => x).Must((model) => { return CheckAppointmentTimeFrom(model); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.AppointmentTimeFromRequired));

            RuleFor(x => x).Must((model) => { return CheckAppointmentTimeTo(model); })
                          .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.AppointmentTimeToRequired));

            RuleFor(x => x).Must((model) => { return CheckOverlapping(model); })
                            .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.TimeNotAvaliable));

            RuleFor(x => x).Must((model) => { return CheckTimeValidation(model); })
                            .WithMessage(_messageResource.GetValidationMessage(ValidationMessageKey.TimeToShouldBeMorethanTimeFrom));

         
        }

        private bool CheckOverlapping(AppointmentInputDTO model)
        {

            if (string.IsNullOrWhiteSpace(model.AppointmentTimeFrom) || string.IsNullOrWhiteSpace(model.AppointmentTimeTo))
                return false;

            if ((!Regex.IsMatch(model.AppointmentTimeFrom, TIME_SPAN_REGULAR_EXPRESSSION)
             || TimeSpan.Parse(model.AppointmentTimeFrom) == default(TimeSpan)))
                return false;

            if ((!Regex.IsMatch(model.AppointmentTimeTo, TIME_SPAN_REGULAR_EXPRESSSION)
             || TimeSpan.Parse(model.AppointmentTimeTo) == default(TimeSpan)))
                return false;

            var appointments = _appointmentRepository.Get(x => x.Id != model.Id &&
                                                      x.AppointmentDate.Date == model.AppointmentDate.Date &&
                                                      x.AppointmentTimeFrom <= TimeSpan.Parse(model.AppointmentTimeTo) &&
                                                      x.AppointmentTimeTo >= TimeSpan.Parse(model.AppointmentTimeFrom));
            return appointments.Count() <= 1;
        }

        bool CheckPatientName(string? patientName) =>
            (!string.IsNullOrWhiteSpace(patientName) && patientName.Length > 0 && patientName.Length < 64);

        bool CheckPatientPhoneNumber(string? patientPhoneNumber) =>
             (!string.IsNullOrWhiteSpace(patientPhoneNumber) && patientPhoneNumber.Length == 11);

        bool CheckAppointmentDate(DateTime? appointmentDate) =>
             (appointmentDate.HasValue && appointmentDate > default(DateTime) && appointmentDate.Value.Date >= DateTime.Now.Date);

        bool CheckAppointmentTimeTo(AppointmentInputDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.AppointmentTimeFrom) || string.IsNullOrWhiteSpace(model.AppointmentTimeTo))
                return false;

            return (Regex.IsMatch(model.AppointmentTimeTo, TIME_SPAN_REGULAR_EXPRESSSION)
             && TimeSpan.Parse(model.AppointmentTimeTo) > default(TimeSpan));
        }

        bool CheckAppointmentTimeFrom(AppointmentInputDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.AppointmentTimeFrom) || string.IsNullOrWhiteSpace(model.AppointmentTimeTo))
                return false;

            return (Regex.IsMatch(model.AppointmentTimeFrom, TIME_SPAN_REGULAR_EXPRESSSION)
             && TimeSpan.Parse(model.AppointmentTimeFrom) > default(TimeSpan));
        }

        bool CheckTimeValidation(AppointmentInputDTO model)
        {
            if (string.IsNullOrWhiteSpace(model.AppointmentTimeFrom) || string.IsNullOrWhiteSpace(model.AppointmentTimeTo))
                return false;

            return (Regex.IsMatch(model.AppointmentTimeFrom, TIME_SPAN_REGULAR_EXPRESSSION) &&
                   Regex.IsMatch(model.AppointmentTimeTo, TIME_SPAN_REGULAR_EXPRESSSION) &&
                   (TimeSpan.Parse(model.AppointmentTimeFrom) > default(TimeSpan)) &&
                     (TimeSpan.Parse(model.AppointmentTimeTo) > default(TimeSpan)) &&
                   (TimeSpan.Parse(model.AppointmentTimeTo) > TimeSpan.Parse(model.AppointmentTimeFrom)));

        }
    }
}
