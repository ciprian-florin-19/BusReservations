using BusReservations.Core.Abstract;
using BusReservations.Core.CommandHandlers;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.BusModel;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
using BusReservations.Infrastructure.Data;

var bus = new Bus
{
    Id = Guid.NewGuid(),
    Capacity = 20,
    Route = null,
    SeatTypes = null
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
    BusId = bus.Id,
    BusName = "generic bus",
    Destination = "Pitesti",
    Start = "Bucuresti",
    SeatNumber = 23,
    SeatType = new StudentSeat(),
    Timetable = new TimeTable()
};
var appDBContext = new AppDBContext();
IUnitOfWork unitOfWork = new UnitOfWork(appDBContext);
//unitOfWork.BusRepository.AddBus(bus);
unitOfWork.UserRepository.AddUser(user);
unitOfWork.ReservationRepository.AddReservation(reservation);
var buses = unitOfWork.BusRepository.GetAllBuses();
var users = unitOfWork.UserRepository.GetAllUsers();
var reservations = unitOfWork.ReservationRepository.GetAllReservations();
unitOfWork.UserRepository.CreateLocalBackup("users.txt");

var addBusCommand = new AddBusCommand() { Bus = bus };
var addBusCommandHandler = new AddBusCommandHandler(unitOfWork);
await addBusCommandHandler.Handle(addBusCommand, new CancellationToken());

var busQuery = new GetBusByIDQuery() { BusID = bus.Id };
var queryHandler = new GetBusByIDQueryHandler(unitOfWork);
var busByID = await queryHandler.Handle(busQuery, new CancellationToken());
Console.ReadLine();