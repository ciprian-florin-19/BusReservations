using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DrivenRoute DrivenRoute { get; set; }
        public Seat? SeatInfo { get; set; }
    }
}