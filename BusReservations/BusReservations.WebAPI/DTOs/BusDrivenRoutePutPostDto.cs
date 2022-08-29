using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class BusDrivenRoutePutPostDto
    {
        [Required]
        public Guid BusId { get; set; }
        [Required]
        public Guid DrivenRouteId { get; set; }
    }
}
