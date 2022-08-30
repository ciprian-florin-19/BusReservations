namespace BusReservations.WebAPI.DTOs
{
    public class ReservationPutPostDto
    {
        public Guid UserId { get; set; }
        public Guid BusDrivenRouteId { get; set; }
        public SeatDto Seat { get; set; }
    }
}
