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

var bus = new Bus
{
    Id = Guid.NewGuid(),
    Capacity = 20,
    Name = "VasileTransports",
};
var user = new User
{
    Id = Guid.NewGuid(),
    Email = "vasile@gmail.com",
    Name = "Vasile",
    PhoneNumber = "071111111",
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
//unitOfWork.UserRepository.AddUser(user);

//var users = unitOfWork.UserRepository.GetAllUsers();
//var reservations = unitOfWork.ReservationRepository.GetAllReservations();
//unitOfWork.UserRepository.CreateLocalBackup("users.csv");

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
//var bus2 = new Bus
//{
//    Id = Guid.NewGuid(),
//    Capacity = 10,
//    Name = "Vasile2Transports"
//};
//unitOfWork.BusRepository.UpdateBus(bus.Id, bus2);
unitOfWork.BusRepository.DeleteBus(bus.Id);
var testCustomer = new Customer(user, Status.student);
var testReservation = new Reservation(user, testCustomer.Id, route1, new ElderlySeat(2));
var testReservation2 = new Reservation(user, testCustomer.Id, route1, new ElderlySeat(2));
var createReservationCommand = new AddReservationCommand()
{
    customerId = testCustomer.Id,
    Reservation = testReservation2,
};
unitOfWork.ReservationRepository.AddReservation(testReservation);
unitOfWork.CustomerRepository.AddCustomer(testCustomer);
var createReservationCommandHandler = new AddReservationCommandHandler(unitOfWork);
await createReservationCommandHandler.Handle(createReservationCommand, new CancellationToken());
var createdReservation = unitOfWork.ReservationRepository.GetAllReservations().ToPagedList(2);
var newCustomer = unitOfWork.CustomerRepository.GetAllCustomers();
unitOfWork.ReservationRepository.AddReservation(testReservation);
var getUserReservationsQuery = new GetCustomerReservationsQuery() { CustomerId = testCustomer.Id };
var getUserReservationsQueryHandler = new GetCustomerReservationsQueryHandler(unitOfWork);

//var cancelReservationCommand = new CancelReservationCommand() { CustomerId = testCustomer.Id, ReservationId = testReservation2.Id };
//var cancelReservationCommandHandler = new CancelReservationCommandHandler(unitOfWork);
//cancelReservationCommandHandler.Handle(cancelReservationCommand, new CancellationToken());
var customerReservations = getUserReservationsQueryHandler.Handle(getUserReservationsQuery, new CancellationToken()).Result;

Console.ReadLine();
