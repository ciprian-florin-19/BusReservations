using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class BusDrivenRouteRepository : IBusDrivenRouteRepository
    {
        private AppDBContext _appDBContext;

        public BusDrivenRouteRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddBusDrivenRoute(BusDrivenRoute busDrivenRoutes)
        {
            _appDBContext.BusDrivenRoutes.Add(busDrivenRoutes);
        }

        public void DeleteBusDrivenRoute(BusDrivenRoute busDrivenRoute)
        {
            _appDBContext.BusDrivenRoutes.Remove(busDrivenRoute);
        }

        public async Task<IEnumerable<BusDrivenRoute>> GetAllBusDrivenRoutes(int pageIndex = 1)
        {
            return await _appDBContext.BusDrivenRoutes.ToPagedListAsync(pageIndex);
        }

        public async Task<BusDrivenRoute> GetBusDrivenRouteByID(Guid id)
        {
            var bdr = await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .Include(bdr => bdr.Bus)
                .SingleOrDefaultAsync(bdr => bdr.Id == id);
            return bdr;
        }

        public void UpdateBusDrivenRoute(BusDrivenRoute busDrivenRoute)
        {
            _appDBContext.Update(busDrivenRoute);
        }

        public async Task<IEnumerable<BusDrivenRoute>> GetAvailableRides(string start, string destination, DateTime departureDate, int pageIndex = 1)
        {
            return await _appDBContext.BusDrivenRoutes.Where(bdr => bdr.Bus.Capacity > bdr.DrivenRoute.OccupiedSeats.Count && bdr.DrivenRoute.TimeTable.DepartureDate.Date == departureDate.Date).ToPagedListAsync(pageIndex);
        }

        public async Task<IEnumerable<DrivenRoute>> GetDrivenRoutesByBus(Guid busId)
        {
            return await _appDBContext.BusDrivenRoutes.Where(bdr => bdr.BusId == busId).Select(bdr => bdr.DrivenRoute).ToPagedListAsync();
        }

        public async Task<ICollection<Bus>> GetBusesByDrivenRoute(Guid RouteId)
        {
            return await _appDBContext.BusDrivenRoutes.Where(bdr => bdr.DrivenRouteId == RouteId).Select(bdr => bdr.Bus).ToPagedListAsync();

        }

        public void AddRange(IEnumerable<BusDrivenRoute> routes)
        {
            _appDBContext.AddRange(routes);
        }
    }
}
