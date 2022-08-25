using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusDrivenRouteRepository
    {
        void AddBusDrivenRoute(BusDrivenRoute busDrivenRoutes);
        Task<IEnumerable<BusDrivenRoute>> GetAllBusDrivenRoutes(int pageIndex = 1);
        Task<BusDrivenRoute> GetBusDrivenRouteByID(Guid id);
        void UpdateBusDrivenRoute(BusDrivenRoute newBusDrivenRoutes);
        void DeleteBusDrivenRoute(BusDrivenRoute newBusDrivenRoutes);
        Task<IEnumerable<BusDrivenRoute>> GetAvailableRides(string start, string destination, DateTime departureDate, int PageIndex = 1);
        Task<IEnumerable<DrivenRoute>> GetDrivenRoutesByBus(Guid busId);
        Task<ICollection<Bus>> GetBusesByDrivenRoute(Guid RouteId);
        void AddRange(IEnumerable<BusDrivenRoute> routes);
    }
}
