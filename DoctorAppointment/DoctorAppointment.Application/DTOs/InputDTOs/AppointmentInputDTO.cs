namespace DoctorAppointment.Application.DTOs.InputDTOs
{
    public class AppointmentInputDTO : BaseInputDTO<int>
    {
        public string? PatientName { get; set; }
        public string? PatientPhoneNumber { get; set; }
        public string? Notes { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? AppointmentTimeFrom { get; set; }
        public string? AppointmentTimeTo { get; set; }
    }
}
