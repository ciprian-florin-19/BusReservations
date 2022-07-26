using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        IEnumerable<Bus> GetAllBuses();
    }
}
