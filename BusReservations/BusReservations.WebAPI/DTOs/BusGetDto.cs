using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class BusGetDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<DrivenRouteSimpleDto> DrivenRoutes { get; set; }
    }
}
