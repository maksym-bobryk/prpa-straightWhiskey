namespace PRPA.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public Barber Barber { get; set; }
        public Client Client { get; set; }
        public DateTime AppointmentTime { get; set; }
        public List<Service> Services { get; set; }
    }
}
