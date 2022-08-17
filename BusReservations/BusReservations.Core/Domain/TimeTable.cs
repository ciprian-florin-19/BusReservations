namespace BusReservations.Core.Domain
{
    public class TimeTable
    {
        public Guid Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArivvalDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}