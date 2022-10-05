namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRouteSimpleDto
    {
        public Guid Id { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public TimeTableGetDto TimeTable { get; set; }
        public float SeatPrice { get; set; }
    }
}
