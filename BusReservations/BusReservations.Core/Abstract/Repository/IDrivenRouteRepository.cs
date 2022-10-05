using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IDrivenRouteRepository
    {
        void AddDrivenRoute(DrivenRoute route);
        Task<DrivenRoute> GetDrivenRouteById(Guid id);
        Task<PagedList<DrivenRoute>> GetAllDrivenRoutes(int index);
        void UpdateDrivenRoute(DrivenRoute route);
        void DeleteDrivenRoute(DrivenRoute route);
        void AddRange(IEnumerable<DrivenRoute> routes);
    }
}
