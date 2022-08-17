using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDBContext _appDBContext;

        public BusRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddBus(Bus bus)
        {
            _appDBContext.Buses?.Add(bus);
            _appDBContext.SaveChanges();
        }

        public void DeleteBus(Guid id)
        {
            _appDBContext.Buses.Remove(GetBusByID(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<Bus> GetAllBuses(int pageIndex = 1)
        {
            return _appDBContext.Buses.ToPagedList(pageIndex);
        }

        public Bus GetBusByID(Guid id)
        {
            return _appDBContext.Buses.FirstOrDefault(bus => bus.Id == id);
        }

        public IEnumerable<Bus> GetBusesByName(string name, int pageIndex = 1)
        {
            return _appDBContext.Buses.Where(bus => bus.Name == name).ToPagedList(pageIndex);
        }

        public void UpdateBus(Guid id, Bus newBus)
        {
            var bus = GetBusByID(id);
            if (bus != null)
            {
                bus = newBus;
                _appDBContext.SaveChanges();
            }
        }
    }
}
