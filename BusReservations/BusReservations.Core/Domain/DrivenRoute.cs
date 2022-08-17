using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class DrivenRoute
    {
        public Guid Id { get; set; }
        public Bus Bus { get; set; }
        public string? Start { get; set; }
        public string? Destination { get; set; }
        public float SeatPrice { get; set; }
        public TimeTable? TimeTable { get; set; }
        public List<Seat> OccupiedSeats { get; set; }
    }
}
