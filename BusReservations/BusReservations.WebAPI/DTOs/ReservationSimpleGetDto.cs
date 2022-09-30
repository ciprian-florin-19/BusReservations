using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class ReservationSimpleGetDto
    {
        public BusDrivenRouteGetDto BusDrivenRoute { get; set; }
        public SeatDto Seat { get; set; }
        public float FinalSeatPrice { get; set; }
    }
}
