using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
