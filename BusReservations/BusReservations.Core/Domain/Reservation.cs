using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.Core.Domain
{
    public class Reservation
    {

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public User User { get; set; }
        public DrivenRoute DrivenRoute { get; set; }
        public Seat SeatInfo { get; set; }

        public float FinalSeatPrice { get; set; }

        public Reservation(User user, Guid customerId, DrivenRoute drivenRoute, Seat seatInfo)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            User = user;
            DrivenRoute = drivenRoute;
            SeatInfo = seatInfo;
            FinalSeatPrice = DrivenRoute.SeatPrice - (DrivenRoute.SeatPrice * (SeatInfo.Discount / 100));
        }
    }
}
