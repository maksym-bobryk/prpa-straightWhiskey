namespace PRPA.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }        
        public string Text { get; set; }        
        public string Photo {get; set; }
        public Appointment Appointment { get; set; }
    }
}
