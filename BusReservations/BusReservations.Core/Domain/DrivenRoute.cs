namespace BusReservations.Core.Domain
{
    public class DrivenRoute
    {
        public Guid Id { get; set; }
        public Bus Bus { get; set; }
        public Route Route { get; set; }
        public float SeatPrice { get; set; }
        public TimeTable? TimeTable { get; set; }
        public List<int> OccupiedSeats { get; set; }
    }
}
