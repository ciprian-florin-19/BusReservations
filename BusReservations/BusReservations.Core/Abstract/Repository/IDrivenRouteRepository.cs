﻿using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IDrivenRouteRepository
    {
        void AddDrivenRoute(DrivenRoute route);
        Task<DrivenRoute> GetDrivenRouteById(Guid id);
        Task<IEnumerable<DrivenRoute>> GetAllDrivenRoutes();
        void UpdateDrivenRoute(DrivenRoute route);
        void DeleteDrivenRoute(DrivenRoute route);
    }
}
