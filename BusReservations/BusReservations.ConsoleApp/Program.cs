using Bogus;
using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.CommandHandlers;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.Factory;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
using BusReservations.Infrastructure.Data;

var buses = new Faker<Bus>("ro")
    .RuleFor(u => u.Id, Guid.NewGuid)
    .RuleFor(u => u.Capacity, f => f.Random.Number(15, 40))
    .RuleFor(u => u.Name, f => f.Company.CompanyName()).Generate(10);

var start = new DateTime(2022, 8, 25, 0, 0, 0);
var end = new DateTime(2022, 8, 25, 12, 0, 0);
var start1 = new DateTime(2022, 8, 25, 12, 0, 0);
var end1 = new DateTime(2022, 8, 25, 20, 0, 0);
var timeTables = new Faker<TimeTable>().CustomInstantiator(f => new TimeTable(f.Date.Between(start, end), f.Date.Between(start1, end1))).Generate(10);

var routes = new Faker<DrivenRoute>("ro")
    .RuleFor(r => r.Id, Guid.NewGuid)
    .RuleFor(r => r.Start, f => f.Address.City())
    .RuleFor(r => r.Destination, f => f.Address.City())
    .RuleFor(r => r.SeatPrice, f => f.Random.Number(20, 100))
    .RuleFor(r => r.TimeTable, f => f.PickRandom(timeTables))
    .Generate(10);

var users = new Faker<User>("ro")
    .RuleFor(u => u.Id, Guid.NewGuid)
    .RuleFor(u => u.Name, f => f.Name.FullName())
    .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
    .RuleFor(u => u.Email, f => f.Internet.Email())
    .RuleFor(u => u.Status, f => f.PickRandom<Status>()).Generate(10);

var bdr = new Faker<BusDrivenRoute>("ro")
    .RuleFor(bdr => bdr.Id, Guid.NewGuid)
    .RuleFor(bdr => bdr.Bus, f => f.PickRandom(buses))
    .RuleFor(bdr => bdr.DrivenRoute, f => f.PickRandom(routes));

var accounts = new Faker<Account>("ro")
    .RuleFor(a => a.Id, Guid.NewGuid)
    .RuleFor(a => a.User, f => f.PickRandom(users))
    .RuleFor(a => a.HasAdminPrivileges, f => f.Random.Bool())
    .RuleFor(a => a.Username, f => f.Internet.UserName())
    .RuleFor(a => a.Password, f => f.Internet.Password()).Generate(10);

var seats = new Faker<Seat>()
    .RuleFor(s => s.Id, Guid.NewGuid)
    .RuleFor(s => s.Discount, f => f.PickRandom(new int[3] { 0, 25, 50 }))
    .RuleFor(s => s.SeatNumber, f => f.Random.Number(f.PickRandom(buses).Capacity))
    .RuleFor(s => s.Type, f => f.PickRandom<Status>()).Generate(10);
var reservations = new Faker<Reservation>().CustomInstantiator(f => new Reservation(f.PickRandom(users), f.PickRandom(bdr), f.PickRandom(seats))).Generate(10);
var dbContext = new AppDBContext();

//dbContext.Database.EnsureDeleted();
//dbContext.Database.EnsureCreated();

var unitOfWork = new UnitOfWork(dbContext);
unitOfWork.UserRepository.AddRange(users);
unitOfWork.BusRepository.AddRange(buses);
unitOfWork.RouteRepository.AddRange(routes);
unitOfWork.BusDrivenRoutesRepository.AddRange(bdr);
unitOfWork.AccountRepository.AddRange(accounts);
unitOfWork.ReservationRepository.AddRange(reservations);
await unitOfWork.SaveChangesAsync();

//Console.WriteLine();

Console.WriteLine();