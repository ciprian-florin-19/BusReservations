using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {
        public DrivenRoute DrivenRoute { get; set; }
        public int SeatNumber { get; set; }
        public Seat? SeatType { get; set; }
    }
}