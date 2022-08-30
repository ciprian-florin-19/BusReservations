using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public BusDrivenRoute BusDrivenRoute { get; set; }
        public Seat Seat { get; set; }
        public Guid UserId { get; set; }
        public Guid BusDrivenRouteId { get; set; }
        public float FinalSeatPrice { get; set; }

        public Reservation() { }

        public Reservation(User user, BusDrivenRoute busDrivenRoute, Seat seat)
        {
            Id = Guid.NewGuid();
            User = user;
            BusDrivenRoute = busDrivenRoute;
            Seat = seat;
            FinalSeatPrice = BusDrivenRoute.DrivenRoute.SeatPrice - (BusDrivenRoute.DrivenRoute.SeatPrice * (Seat.Discount / 100));
            BusDrivenRouteId = busDrivenRoute.Id;
            UserId = user.Id;
            busDrivenRoute.OccupiedSeats.Append(seat);
        }
    }
}
