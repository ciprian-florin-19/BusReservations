﻿using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
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

        public async Task<PagedList<BusDrivenRoute>> GetAllBusDrivenRoutes(int pageIndex = 1)
        {
            return await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(bdr => bdr.Bus)
                .Include(bdr => bdr.OccupiedSeats)
                .Include(bdr => bdr.DrivenRoute)
                .Where(bdr => bdr.Bus.Capacity > bdr.OccupiedSeats.Count)
                .ToPagedListAsync(pageIndex);
        }

        public async Task<BusDrivenRoute> GetBusDrivenRouteByID(Guid id)
        {
            var bdr = await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(bdr => bdr.Bus)
                .Include(bdr => bdr.OccupiedSeats)
                .Include(bdr => bdr.DrivenRoute)
                .SingleOrDefaultAsync(bdr => bdr.Id == id);
            return bdr;
        }

        public void UpdateBusDrivenRoute(BusDrivenRoute busDrivenRoute)
        {
            _appDBContext.Update(busDrivenRoute);
        }

        public async Task<PagedList<BusDrivenRoute>> GetAvailableRides(string start, string destination, DateTime departureDate, int pageIndex = 1)
        {
            return await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(bdr => bdr.DrivenRoute)
                .Include(bdr => bdr.DrivenRoute)
                .Include(bdr => bdr.OccupiedSeats)
                .Include(bdr => bdr.Bus)
                .Where(bdr => bdr.Bus.Capacity > bdr.OccupiedSeats.Count()
                && bdr.DrivenRoute.TimeTable.DepartureDate.Date == departureDate.Date
                && bdr.DrivenRoute.Start == start
                && bdr.DrivenRoute.Destination == destination).ToPagedListAsync(pageIndex);
        }

        public async Task<IEnumerable<DrivenRoute>> GetDrivenRoutesByBus(Guid busId)
        {
            return await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Where(bdr => bdr.BusId == busId).Select(bdr => bdr.DrivenRoute).ToPagedListAsync();
        }

        public async Task<ICollection<Bus>> GetBusesByDrivenRoute(Guid RouteId)
        {
            return await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.Bus)
                .Where(bdr => bdr.DrivenRouteId == RouteId).Select(bdr => bdr.Bus).ToPagedListAsync();
        }

        public void AddRange(IEnumerable<BusDrivenRoute> routes)
        {
            _appDBContext.AddRange(routes);
        }

        public async Task<PagedList<BusDrivenRoute>> GetBusDrivenRoutesByDate(DateTime date, int pageIndex = 1)
        {
            return await _appDBContext.BusDrivenRoutes
                .Include(bdr => bdr.DrivenRoute)
                .ThenInclude(dr => dr.TimeTable)
                .Include(bdr => bdr.Bus)
                .Include(bdr => bdr.OccupiedSeats)
                .Include(bdr => bdr.DrivenRoute)
                .Where(bdr => bdr.DrivenRoute.TimeTable.DepartureDate.Date == date.Date)
                .ToPagedListAsync(pageIndex);
        }
    }
}
