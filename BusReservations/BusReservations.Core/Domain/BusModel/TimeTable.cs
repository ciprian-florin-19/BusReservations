namespace BusReservations.Core.Domain.BusModel
{
    public class TimeTable
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArivvalDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}