using Bogus;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.WebApi.Tests
{
    public class Utilities
    {
        public static void InitializeDBForTests(AppDBContext context)
        {
            //generate dummy data
            var buses = new List<Bus>
            {
               new Bus
               {
                   Id=new Guid("74cd2565-4101-4e4f-904d-2cb5eb924790"),
                   Name="Vasile Transports",
                   Capacity=20,
               },
               new Bus
               {
                   Id=new Guid("cdecd2eb-4a6f-4300-b89d-d4e1e8d0ee22"),
                   Name="Gigel Transports",
                   Capacity=30
               },
               new Bus
               {
                   Id=new Guid("38e08881-bdce-4892-b89e-3f61aec49f33"),
                   Name="Andrei Transports",
                   Capacity=25
               },
            };
            var timeTables = new List<TimeTable>
            {
                new TimeTable
                {
                    Id = new Guid("ad627a4f-8125-4b58-a300-f5d38cff7e32"),
                    DepartureDate=new DateTime(2022,09,22,5,30,0),
                    ArivvalDate=new DateTime(2022,09,22,6,30,0),
                    Duration=new TimeSpan(1,0,0),
                },
                new TimeTable
                {
                    Id = new Guid("bbad604f-1385-444a-96dc-651ab8f3336b"),
                    DepartureDate=new DateTime(2022,10,12,12,30,0),
                    ArivvalDate=new DateTime(2022,10,12,14,0,0),
                    Duration=new TimeSpan(1,30,0),
                }
            };
            var drivenRoutes = new List<DrivenRoute>
            {
                new DrivenRoute
                {
                    Id=new Guid("c44721d0-c3cd-4b44-933e-19905d8aed23"),
                    Start="Pitesti",
                    Destination="Sibiu",
                    SeatPrice=60,
                    TimeTable=timeTables[0]
                },
                new DrivenRoute
                {
                    Id=new Guid("bb775bb2-61c0-4f4f-9d39-53c9976c0d61"),
                    Start="Campulung",
                    Destination="Brasov",
                    SeatPrice=60,
                    TimeTable=timeTables[0]
                },
                new DrivenRoute
                {
                    Id=new Guid("49d27d89-0d61-4ded-9267-d8df39a7b38d"),
                    Start="Brasov",
                    Destination="Campulung",
                    SeatPrice=40,
                    TimeTable=timeTables[0]
                }
            };
            var busDrivenRoutes = new List<BusDrivenRoute>
            {
                new BusDrivenRoute
                {
                    Id=new Guid("9c525fa0-b3c8-4610-8819-e82f58dfe7e3"),
                    Bus=buses[0],
                    BusId=buses[0].Id,
                    DrivenRoute=drivenRoutes[0],
                    DrivenRouteId=drivenRoutes[0].Id,
                },
                new BusDrivenRoute
                {
                    Id=new Guid("a414ba36-a888-4449-a9f7-d60371a6d1bf"),
                    Bus=buses[0],
                    BusId=buses[0].Id,
                    DrivenRoute=drivenRoutes[1],
                    DrivenRouteId=drivenRoutes[1].Id,
                },
                new BusDrivenRoute
                {
                    Id=new Guid("1b5c13ce-fe0f-40c6-81f6-924b119629bc"),
                    Bus=buses[2],
                    BusId=buses[2].Id,
                    DrivenRoute=drivenRoutes[1],
                    DrivenRouteId=drivenRoutes[1].Id,
                },
            };
            //var start = new DateTime(2022, 8, 25, 0, 0, 0);
            //var end = new DateTime(2022, 8, 25, 12, 0, 0);
            //var start1 = new DateTime(2022, 8, 25, 12, 0, 0);
            //var end1 = new DateTime(2022, 8, 25, 20, 0, 0);
            //var timeTables = new Faker<TimeTable>().CustomInstantiator(f => new TimeTable(f.Date.Between(start, end), f.Date.Between(start1, end1))).Generate(10);

            //var routes = new Faker<DrivenRoute>("ro")
            //    .RuleFor(r => r.Id, Guid.NewGuid)
            //    .RuleFor(r => r.Start, f => f.Address.City())
            //    .RuleFor(r => r.Destination, f => f.Address.City())
            //    .RuleFor(r => r.SeatPrice, f => f.Random.Number(20, 100))
            //    .RuleFor(r => r.TimeTable, f => f.PickRandom(timeTables))
            //    .Generate(10);

            //var users = new Faker<User>("ro")
            //    .RuleFor(u => u.Id, Guid.NewGuid)
            //    .RuleFor(u => u.Name, f => f.Name.FullName())
            //    .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            //    .RuleFor(u => u.Email, f => f.Internet.Email())
            //    .RuleFor(u => u.Status, f => f.PickRandom<Status>()).Generate(10);

            //var bdr = new Faker<BusDrivenRoute>("ro")
            //    .RuleFor(bdr => bdr.Id, Guid.NewGuid)
            //    .RuleFor(bdr => bdr.Bus, f => f.PickRandom(buses))
            //    .RuleFor(bdr => bdr.DrivenRoute, f => f.PickRandom(routes)).Generate(10);

            //var accounts = new Faker<Account>("ro")
            //    .RuleFor(a => a.Id, Guid.NewGuid)
            //    .RuleFor(a => a.User, f => f.PickRandom(users))
            //    .RuleFor(a => a.HasAdminPrivileges, f => f.Random.Bool())
            //    .RuleFor(a => a.Username, f => f.Internet.UserName())
            //    .RuleFor(a => a.Password, f => f.Internet.Password()).Generate(10);

            //var seats = new Faker<Seat>()
            //    .RuleFor(s => s.Id, Guid.NewGuid)
            //    .RuleFor(s => s.Discount, f => f.PickRandom(new int[3] { 0, 25, 50 }))
            //    .RuleFor(s => s.SeatNumber, f => f.Random.Number(f.PickRandom(buses).Capacity))
            //    .RuleFor(s => s.Type, f => f.PickRandom<Status>()).Generate(10);
            //var reservations = new Faker<Reservation>().CustomInstantiator(f => new Reservation(f.PickRandom(users), f.PickRandom(bdr), f.PickRandom(seats))).Generate(10);

            //add data to InMemoryDb
            context.Buses.AddRange(buses);
            context.TimeTables.AddRange(timeTables);
            context.DrivenRoutes.AddRange(drivenRoutes);
            //context.Users.AddRange(users);
            context.BusDrivenRoutes.AddRange(busDrivenRoutes);
            //context.Accounts.AddRange(accounts);
            //context.Seats.AddRange(seats);
            //context.Reservations.AddRange(reservations);
            context.SaveChanges();
        }
    }
}
