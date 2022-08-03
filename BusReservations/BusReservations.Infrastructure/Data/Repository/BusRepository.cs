using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain.BusModel;

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
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            return _appDBContext.Buses.ToList();
        }

        public Bus GetBusByID(Guid busId)
        {
            return _appDBContext.Buses.SingleOrDefault(bus => bus.Id == busId);
        }
    }
}
