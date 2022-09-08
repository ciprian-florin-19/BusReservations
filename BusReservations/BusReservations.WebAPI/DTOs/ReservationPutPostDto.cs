using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class ReservationPutPostDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BusDrivenRouteId { get; set; }

        [Required]
        public SeatDto Seat { get; set; }
    }
}
