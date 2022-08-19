using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IBusDrivenRouteRepository
    {
        void AddBusDrivenRoute(BusDrivenRoute busDrivenRoutes);
        IEnumerable<BusDrivenRoute> GetAllBusDrivenRoutes(int pageIndex = 1);
        BusDrivenRoute GetBusDrivenRouteByID(Guid id);
        void UpdateBusDrivenRoute(Guid id, BusDrivenRoute newBusDrivenRoutes);
        void DeleteBusDrivenRoute(Guid id);
        IEnumerable<BusDrivenRoute> GetAvailableRides(string start, string destination, DateTime departureDate, int PageIndex = 1);
        IEnumerable<DrivenRoute> GetDrivenRoutesByBus(Guid busId);
        ICollection<Bus> GetBusesByDrivenRoute(Guid RouteId);
    }
}
