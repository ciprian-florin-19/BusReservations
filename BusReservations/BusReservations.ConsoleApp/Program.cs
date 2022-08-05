using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.CommandHandlers;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.Factory;
using BusReservations.Core.Domain.SeatModel;
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
    Status = "student"
};
var reservation = new Reservation
{
    SeatNumber = 23,
    SeatType = new StudentSeat(),
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
var buses = unitOfWork.BusRepository.GetAllBuses();
var busPage = buses.ToPagedList(1, 2);

//Factory
IUserFactory userFactory;

//create customer
userFactory = new CustomerFactory();
var customer = userFactory.CreateUser();

//create admin
userFactory = new AdminFactory();
var admin = userFactory.CreateUser();

Console.ReadLine();