namespace BusReservations.Core.Domain
{
    public class TimeTable
    {
        public Guid Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArivvalDate { get; set; }
        public TimeSpan Duration { get; set; }

        public TimeTable()
        {

        }
        public TimeTable(DateTime departure, DateTime arrival)
        {
            Id = Guid.NewGuid();
            DepartureDate = departure;
            ArivvalDate = arrival;
            Duration = ArivvalDate - DepartureDate;
        }
    }
}