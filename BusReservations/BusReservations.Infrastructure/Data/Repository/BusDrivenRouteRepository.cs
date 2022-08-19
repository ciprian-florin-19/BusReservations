using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
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
            _appDBContext.SaveChanges();
        }

        public void DeleteBusDrivenRoute(Guid id)
        {
            _appDBContext.BusDrivenRoutes.Remove(GetBusDrivenRouteByID(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<BusDrivenRoute> GetAllBusDrivenRoutes(int pageIndex = 1)
        {
            return _appDBContext.BusDrivenRoutes.ToPagedList(pageIndex);
        }

        public BusDrivenRoute GetBusDrivenRouteByID(Guid id)
        {
            return _appDBContext.BusDrivenRoutes.FirstOrDefault(bdr => bdr.Id == id);
        }

        public void UpdateBusDrivenRoute(Guid id, BusDrivenRoute newBusDrivenRoutes)
        {
            var bdr = GetBusDrivenRouteByID(id);
            if (bdr != null)
            {
                bdr = newBusDrivenRoutes;
                _appDBContext.SaveChanges();
            }
        }

        public IEnumerable<BusDrivenRoute> GetAvailableRides(string start, string destination, DateTime departureDate, int pageIndex = 1)
        {
            return _appDBContext.BusDrivenRoutes.Where(bdr => bdr.Bus.Capacity > bdr.DrivenRoute.OccupiedSeats.Count && bdr.DrivenRoute.TimeTable.DepartureDate.Date == departureDate.Date).ToPagedList(pageIndex);
        }

        public IEnumerable<DrivenRoute> GetDrivenRoutesByBus(Guid busId)
        {
            return _appDBContext.BusDrivenRoutes.Where(bdr => bdr.BusId == busId).Select(bdr => bdr.DrivenRoute).ToPagedList();
        }

        public ICollection<Bus> GetBusesByDrivenRoute(Guid RouteId)
        {
            return _appDBContext.BusDrivenRoutes.Where(bdr => bdr.DrivenRouteId == RouteId).Select(bdr => bdr.Bus).ToPagedList();

        }
    }
}
