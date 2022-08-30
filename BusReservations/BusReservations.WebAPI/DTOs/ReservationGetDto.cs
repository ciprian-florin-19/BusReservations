using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.WebAPI.DTOs
{
    public class ReservationGetDto
    {
        public UserGetDto User { get; set; }

        public DrivenRouteSimpleDto DrivenRoute { get; set; }
        public BusSimpleDto Bus { get; set; }
        public SeatDto Seat { get; set; }
        public float FinalSeatPrice { get; set; }
    }
}
