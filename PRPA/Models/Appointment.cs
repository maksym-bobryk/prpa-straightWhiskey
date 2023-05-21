namespace PRPA.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int BarberId { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
