using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.BusModel;
using BusReservations.Infrastructure.Data;

var bus = new Bus
{
    Id = Guid.NewGuid(),
    Capacity = 20,
    Route = null,
    SeatTypes=null
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
unitOfWork.BusRepository.AddBus(bus);
unitOfWork.UserRepository.AddUser(user);
unitOfWork.ReservationRepository.AddReservation(reservation);
var buses = unitOfWork.BusRepository.GetAllBuses();
var users = unitOfWork.UserRepository.GetAllUsers();
var reservations = unitOfWork.ReservationRepository.GetAllReservations();
Console.ReadLine();