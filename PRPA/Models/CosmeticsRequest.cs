namespace PRPA.Models
{
    public class CosmeticsRequest
    {
        public int CosmeticsRequestId { get; set; }
        public Barber Barber { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
