using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class BusDrivenRouteGetDto
    {
        public Guid Id { get; set; }
        public BusSimpleDto Bus { get; set; }
        public DrivenRouteSimpleDto DrivenRoute { get; set; }
        public IEnumerable<SeatDto> OccupiedSeats { get; set; }
    }
}
