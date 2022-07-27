using BusReservations.Core.Domain.BusModel;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        IEnumerable<Bus> GetAllBuses();
    }
}
