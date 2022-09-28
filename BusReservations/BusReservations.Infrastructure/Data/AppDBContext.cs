using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BusReservations.Infrastructure.Data
{
    public class AppDBContext : IdentityDbContext<Account>
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {
        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<DrivenRoute> DrivenRoutes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<BusDrivenRoute> BusDrivenRoutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BusReservations;Trusted_Connection=True;TrustServerCertificate=True");
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder
        //        .Entity<User>()
        //        .Property(u => u.Status)
        //        .HasConversion(
        //        s => s.ToString(),
        //        s => (Status)Enum.Parse(typeof(Status), s));
        //}
    }
}
