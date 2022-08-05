using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IDrivenRouteRepository
    {
        public void AddDrivenRoute(DrivenRoute route);
        public IEnumerable<DrivenRoute> GetAllDrivenRoutes();
    }
}
