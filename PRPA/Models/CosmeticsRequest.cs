using System.ComponentModel.DataAnnotations.Schema;

namespace PRPA.Models
{
    public class CosmeticsRequest
    {
        public int CosmeticsRequestId { get; set; }

        [ForeignKey("BarberId")]
        public Barber Barber { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
