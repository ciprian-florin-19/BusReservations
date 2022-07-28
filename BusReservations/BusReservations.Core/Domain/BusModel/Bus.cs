namespace BusReservations.Core.Domain.BusModel
{
    public class Bus
    {
        public Guid Id { get; set; }
        public int Capacity { get; set; }
        public Route? Route { get; set; }
        public float SeatPrice { get; set; }
        public List<Seat>? SeatTypes { get; set; }
    }
}
