using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IDrivenRouteRepository
    {
        void AddDrivenRoute(DrivenRoute route);
        Task<DrivenRoute> GetDrivenRouteById(Guid id);
        Task<IEnumerable<DrivenRoute>> GetAllDrivenRoutes(int index);
        void UpdateDrivenRoute(DrivenRoute route);
        void DeleteDrivenRoute(DrivenRoute route);
        void AddRange(IEnumerable<DrivenRoute> routes);
    }
}
