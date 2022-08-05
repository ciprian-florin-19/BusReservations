namespace BusReservations.Core.Domain
{
    public class Customer : User
    {
        public List<Reservation>? Reservations { get; set; }
    }
}
