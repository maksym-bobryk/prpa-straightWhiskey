using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class Barber
    {
        public int BarberId { get; set; }
        public decimal Earnings { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
