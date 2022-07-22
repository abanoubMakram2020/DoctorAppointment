namespace DoctorAppointment.Application.DTOs.InputDTOs
{
    public class BaseInputDTO<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
