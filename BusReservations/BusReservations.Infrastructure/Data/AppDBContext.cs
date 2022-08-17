using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservations.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<DrivenRoute> DrivenRoutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BusReservations;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
