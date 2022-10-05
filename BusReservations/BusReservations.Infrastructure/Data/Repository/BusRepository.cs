using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using Microsoft.EntityFrameworkCore;

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
            _appDBContext.Buses.Add(bus);
        }

        public void AddRange(IEnumerable<Bus> buses)
        {
            _appDBContext.Buses.AddRange(buses);
        }

        public void DeleteBus(Bus bus)
        {
            _appDBContext.Buses.Remove(bus);
        }

        public async Task<PagedList<Bus>> GetAllBuses(int pageIndex = 1)
        {
            return await _appDBContext.Buses
                .Include(x => x.BusDrivenRoutes)
                .ThenInclude(x => x.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(x => x.BusDrivenRoutes)
                .ThenInclude(x => x.OccupiedSeats)
                .ToPagedListAsync(pageIndex);
        }

        public async Task<Bus> GetBusByID(Guid id)
        {
            var bus = await _appDBContext.Buses
                .Include(x => x.BusDrivenRoutes)
                .ThenInclude(x => x.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(x => x.BusDrivenRoutes)
                .ThenInclude(x => x.OccupiedSeats)
                .SingleOrDefaultAsync(bus => bus.Id == id);

            return bus;
        }

        public async Task<IEnumerable<Bus>> GetBusesByName(string name, int pageIndex = 1)
        {
            return await _appDBContext.Buses.Where(bus => bus.Name == name).ToPagedListAsync(pageIndex);
        }

        public void UpdateBus(Bus bus)
        {
            _appDBContext.Update(bus);
        }
    }
}
