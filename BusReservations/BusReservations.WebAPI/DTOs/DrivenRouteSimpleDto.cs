namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRouteSimpleDto
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public TimeTableDto TimeTable { get; set; }
        public float SeatPrice { get; set; }
    }
}
