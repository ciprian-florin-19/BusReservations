using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data
{
    public class AppDBContext : IDbContext
    {
        public List<Bus> Buses { get; set; } = new List<Bus>();
        public List<User> Users { get; set; } = new List<User>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<DrivenRoute> DrivenRoutes { get; set; } = new List<DrivenRoute>();
    }
}
