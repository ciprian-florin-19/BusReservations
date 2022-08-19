using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {

        public Guid Id { get; set; }
        public User User { get; set; }
        public DrivenRoute DrivenRoute { get; set; }
        public Seat Seat { get; set; }

        public float FinalSeatPrice { get; set; }

        public Reservation() { }

        public Reservation(User user, DrivenRoute drivenRoute, Seat seat)
        {
            Id = Guid.NewGuid();
            User = user;
            DrivenRoute = drivenRoute;
            Seat = seat;
            FinalSeatPrice = DrivenRoute.SeatPrice - (DrivenRoute.SeatPrice * (Seat.Discount / 100));
            drivenRoute.OccupiedSeats.Add(seat);
        }
    }
}
