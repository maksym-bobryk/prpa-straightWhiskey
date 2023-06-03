using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        [ForeignKey("AppointmentId")]
        public List<Appointment> Appointments { get; set; }
    }
}
