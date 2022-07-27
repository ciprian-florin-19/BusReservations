namespace BusReservations.Core.Domain.BusModel
{
    public class Route
    {
        public string? Start { get; set; }
        public string? Destination { get; set; }
        public int SeatsCount { get; set; }
        public TimeTable? TimeTable { get; set; }
    }
}