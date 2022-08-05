using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class DrivenRouteRepository : IDrivenRouteRepository
    {
        private readonly AppDBContext _appDBContext;

        public DrivenRouteRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException();
        }

        public void AddDrivenRoute(DrivenRoute route)
        {

        }

        public IEnumerable<DrivenRoute> GetAllDrivenRoutes()
        {
            throw new NotImplementedException();
        }
    }
}
