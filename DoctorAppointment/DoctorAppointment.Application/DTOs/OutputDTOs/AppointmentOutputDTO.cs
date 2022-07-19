namespace DoctorAppointment.Application.DTOs.OutputDTOs
{
    public class AppointmentOutputDTO : BaseOutputDTO<int>
    {
        public string? PatientName { get; set; }
        public string? PatientPhoneNumber { get; set; }
        public string? Notes { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTimeFrom { get; set; }
        public TimeSpan AppointmentTimeTo { get; set; }
    }
}
