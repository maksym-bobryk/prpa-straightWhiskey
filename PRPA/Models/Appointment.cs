using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [ForeignKey("BarberId")]
        public Barber Barber { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public DateTime AppointmentTime { get; set; }

        [ForeignKey("ServiceId")]
        public List<Service> Services { get; set; }
    }
}
