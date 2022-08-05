using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        IEnumerable<Bus> GetAllBuses(int pageIndex = 1);
        Bus GetBusByID(Guid busId);
    }
}
