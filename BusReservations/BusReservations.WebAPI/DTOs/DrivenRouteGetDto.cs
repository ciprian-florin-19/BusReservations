using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRouteGetDto
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public TimeTableGetDto TimeTable { get; set; }
        public float SeatPrice { get; set; }
        public ICollection<BusSimpleDto> Buses { get; set; }

    }
}
