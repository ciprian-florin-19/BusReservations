namespace BusReservations.Core.Domain
{
    public class Route
    {
        public Guid Id { get; set; }
        public string? Start { get; set; }
        public string? Destination { get; set; }
    }
}