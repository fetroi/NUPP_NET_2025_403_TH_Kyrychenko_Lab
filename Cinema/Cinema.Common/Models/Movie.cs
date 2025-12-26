namespace Cinema.Common.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public int DurationMinutes { get; set; }
        public double Rating { get; set; }   // 0..10
    }
}
