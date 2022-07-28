using BusReservations.Core.Domain.BusModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {
        public Guid BusId { get; set; }
        public string? BusName { get; set; }
        public string? Start { get; set; }
        public string? Destination { get; set; }
        public TimeTable? Timetable { get; set; }
        public int SeatNumber { get; set; }
        public Seat? SeatType { get; set; }
    }
}