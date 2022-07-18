namespace DoctorAppointment.Domain.Data.Entities
{
    public class Appointment : BaseEntity<int>
    {
        public string?   PatientName     { get; set; }
        public string?   PatientPhoneNumber { get; set; }
        public string?   Notes { get; set; }
        public DateTime AppointmentDate  { get; set; }
        public TimeSpan AppointmentTimeFrom { get; set; }
        public TimeSpan AppointmentTimeTo { get; set; }
    }
}
