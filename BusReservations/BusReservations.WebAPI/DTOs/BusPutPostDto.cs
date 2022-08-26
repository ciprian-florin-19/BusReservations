using BusReservations.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class BusPutPostDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Range(20, 50)]
        public int Capacity { get; set; }

        public ICollection<DrivenRouteGetDto> DrivenRoutes { get; set; }
    }
}
