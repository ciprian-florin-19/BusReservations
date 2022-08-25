﻿using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class DrivenRouteRepository : IDrivenRouteRepository
    {
        private readonly AppDBContext _appDBContext;

        public DrivenRouteRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddDrivenRoute(DrivenRoute route)
        {
            _appDBContext.DrivenRoutes.Add(route);
        }

        public void AddRange(IEnumerable<DrivenRoute> routes)
        {
            _appDBContext.AddRange(routes);
        }

        public void DeleteDrivenRoute(DrivenRoute route)
        {
            _appDBContext.DrivenRoutes.Remove(route);
        }

        public async Task<IEnumerable<DrivenRoute>> GetAllDrivenRoutes()
        {
            return await _appDBContext.DrivenRoutes.ToPagedListAsync();
        }

        public async Task<DrivenRoute> GetDrivenRouteById(Guid id)
        {
            var route = await _appDBContext.DrivenRoutes.SingleOrDefaultAsync(route => route.Id == id);
            return route;
        }

        public void UpdateDrivenRoute(DrivenRoute route)
        {
            _appDBContext.Update(route);
        }
    }
}
