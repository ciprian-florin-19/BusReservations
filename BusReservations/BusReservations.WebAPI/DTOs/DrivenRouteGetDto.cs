using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;

namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRouteGetDto
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public ICollection<SeatDto> OccupiedSeats { get; set; }
        public TimeTableDto TimeTable { get; set; }
        public float SeatPrice { get; set; }

    }
}
