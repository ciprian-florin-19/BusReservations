namespace BusReservations.Core.Domain
{
    public class Bus
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<BusDrivenRoute> BusDrivenRoutes { get; set; } = new List<BusDrivenRoute>();
    }
}
