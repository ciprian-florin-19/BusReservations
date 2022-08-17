using BusReservations.Core.Abstract.Repository;

namespace BusReservations.Core.Abstract
{
    public interface IUnitOfWork
    {
        IBusRepository BusRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        IDrivenRouteRepository RouteRepository { get; set; }
    }
}
