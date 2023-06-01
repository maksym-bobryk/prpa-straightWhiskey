namespace PRPA.Models
{
    public class AppointmentService
    {
        public int AppointmentServiceId { get; set; }
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}
