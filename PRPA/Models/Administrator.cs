using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
