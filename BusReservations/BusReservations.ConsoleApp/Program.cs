using BusReservations.Core.Abstract;
using BusReservations.Core.Domain.BusModel;
using BusReservations.Infrastructure.Data;

var bus = new Bus
{
    Id = Guid.NewGuid(),
    Capacity = 20,
    Route = null,
    SeatTypes=null
};
var appDBContext = new AppDBContext();
IUnitOfWork unitOfWork = new UnitOfWork(appDBContext);
unitOfWork.BusRepository.AddBus(bus);
var buses = unitOfWork.BusRepository.GetAllBuses();
Console.ReadLine();
//TO DO: Models, Repos