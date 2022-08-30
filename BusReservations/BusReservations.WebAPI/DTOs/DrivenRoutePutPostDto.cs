namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRoutePutPostDto
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public TimeTableDto TimeTable { get; set; }
        public float SeatPrice { get; set; }
        private ICollection<BusSimpleDto> Buses { get; set; }
    }
}
