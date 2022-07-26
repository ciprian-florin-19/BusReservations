namespace BusReservations.Core.Domain
{
    public class Bus
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public Route? Route { get; set; }
        public List<Seat>? SeatTypes { get; set; }
    }
}
