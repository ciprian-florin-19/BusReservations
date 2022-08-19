using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IDrivenRouteRepository
    {
        void AddDrivenRoute(DrivenRoute route);
        DrivenRoute GetDrivenRouteById(Guid id);
        IEnumerable<DrivenRoute> GetAllDrivenRoutes();
        void UpdateDrivenRoute(Guid id, DrivenRoute newRoute);
        void DeleteDrivenRoute(Guid id);
    }
}
