using BusReservations.Core.Abstract;
using BusReservations.Core.CommandHandlers;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.Factory;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
using BusReservations.Infrastructure.Data;

var bus = new Bus
{
    Id = Guid.NewGuid(),
    Capacity = 2,
    Name = "VasileTransports",
};
var user = new User
{
    Id = Guid.NewGuid(),
    Email = "vasile@gmail.com",
    Name = "Vasile",
    PhoneNumber = "071111111",
    Status = "student"
};
var reservation = new Reservation
{
    SeatInfo = new StudentSeat(2),
    DrivenRoute = new DrivenRoute(),
    Id = Guid.NewGuid(),
};
var appDBContext = new AppDBContext();
IUnitOfWork unitOfWork = new UnitOfWork(appDBContext);
unitOfWork.BusRepository.AddBus(
    new Bus
    {
        Id = Guid.NewGuid(),
        Capacity = 10,
        Name = "GigelTransports"
    });
unitOfWork.UserRepository.AddUser(user);
unitOfWork.ReservationRepository.AddReservation(reservation);

var users = unitOfWork.UserRepository.GetAllUsers();
var reservations = unitOfWork.ReservationRepository.GetAllReservations();
unitOfWork.UserRepository.CreateLocalBackup("users.csv");

var addBusCommand = new AddBusCommand() { Bus = bus };
var addBusCommandHandler = new AddBusCommandHandler(unitOfWork);
await addBusCommandHandler.Handle(addBusCommand, new CancellationToken());

//var busQuery = new GetBusByIDQuery() { BusID = bus.Id };
//var queryHandler = new GetBusByIDQueryHandler(unitOfWork);
//var busByID = await queryHandler.Handle(busQuery, new CancellationToken());
var buses = unitOfWork.BusRepository.GetAllBuses(2);

//Factory
IUserFactory userFactory;

//create customer
userFactory = new CustomerFactory();
var customer = userFactory.CreateUser();

//create admin
userFactory = new AdminFactory();
var admin = userFactory.CreateUser();

//get available routes for given travel points

var route1 = new DrivenRoute
{
    Id = Guid.NewGuid(),
    Bus = bus,
    Start = "Pitesti",
    Destination = "Sibiu",
    OccupiedSeats = new List<int> { 1, 2 },
    SeatPrice = 50,
    TimeTable = new TimeTable
    {
        DepartureDate = new DateTime(2022, 5, 12, 15, 21, 0),
        ArivvalDate = new DateTime(2022, 5, 12, 18, 51, 0),
        Duration = new TimeSpan(3, 30, 0)
    },
};
var route2 = new DrivenRoute
{
    Id = Guid.NewGuid(),
    Bus = bus,
    Start = "Pitesti",
    Destination = "Sibiu",
    OccupiedSeats = new List<int> { 1 },
    SeatPrice = 70,
    TimeTable = new TimeTable
    {
        DepartureDate = new DateTime(2022, 5, 12, 8, 0, 0),
        ArivvalDate = new DateTime(2022, 5, 12, 11, 30, 0),
        Duration = new TimeSpan(3, 30, 0)
    },
};
var route3 = new DrivenRoute
{
    Id = Guid.NewGuid(),
    Bus = bus,
    Start = "Pitesti",
    Destination = "Sibiu",
    OccupiedSeats = new List<int>(),
    SeatPrice = 30,
    TimeTable = new TimeTable
    {
        DepartureDate = new DateTime(2022, 5, 12, 12, 0, 0),
        ArivvalDate = new DateTime(2022, 5, 12, 3, 30, 0),
        Duration = new TimeSpan(3, 30, 0)
    },
};
var routesQuery = new GetAvailableRidesQuery()
{
    DepartureDate = new DateTime(2022, 5, 12),
    Start = "Pitesti",
    Destination = "Sibiu",
    PageIndex = 1
};
unitOfWork.RouteRepository.AddDrivenRoute(route1);
unitOfWork.RouteRepository.AddDrivenRoute(route2);
unitOfWork.RouteRepository.AddDrivenRoute(route3);
var routesQueryhandler = new GetAvailableRidesQueryHandler(unitOfWork);
var availableRoutes = routesQueryhandler.Handle(routesQuery, new CancellationToken()).Result;
Console.ReadLine();