using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

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
            _appDBContext.SaveChanges();
        }

        public void DeleteDrivenRoute(Guid id)
        {
            _appDBContext.DrivenRoutes.Remove(GetDrivenRouteById(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<DrivenRoute> GetAllDrivenRoutes()
        {
            return _appDBContext.DrivenRoutes.ToPagedList();
        }

        public DrivenRoute GetDrivenRouteById(Guid id)
        {
            return _appDBContext.DrivenRoutes.FirstOrDefault(route => route.Id == id);
        }

        public void UpdateDrivenRoute(Guid id, DrivenRoute newRoute)
        {
            var route = GetDrivenRouteById(id);
            if (route != null)
            {
                route = newRoute;
                _appDBContext.SaveChanges();
            }
        }
    }
}
