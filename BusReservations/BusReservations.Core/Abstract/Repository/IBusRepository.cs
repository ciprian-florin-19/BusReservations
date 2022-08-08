using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusRepository
    {
        void AddBus(Bus bus);
        IEnumerable<Bus> GetAllBuses(int pageIndex = 1);
        Bus GetBusByID(Guid busId);
        IEnumerable<Bus> GetBusesByName(string name, int pageIndex = 1);
        void UpdateBus(Guid id, Bus newBus);
        void DeleteBus(Guid id);
    }
}
