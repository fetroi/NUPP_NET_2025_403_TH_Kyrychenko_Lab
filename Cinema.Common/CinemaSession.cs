namespace Cinema.Common
{
    public record CinemaSession
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string MovieTitle { get; init; }
        public DateTime StartTime { get; init; }
        public int AvailableSeats { get; set; }

        public override string ToString()
            => $"[{Id}] {MovieTitle} @ {StartTime}, Seats: {AvailableSeats}";
    }
}
