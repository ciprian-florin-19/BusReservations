using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class BusDrivenRouteGetDto
    {
        public Guid Id { get; set; }
        public BusSimpleDto Bus { get; set; }
        public DrivenRouteGetDto DrivenRoute { get; set; }
    }
}
