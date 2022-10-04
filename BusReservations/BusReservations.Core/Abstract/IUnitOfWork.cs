using BusReservations.Core.Abstract.Repository;
using SeatReservations.Core.Abstract.Repository;

namespace BusReservations.Core.Abstract
{
    public interface IUnitOfWork
    {
        IBusRepository BusRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
        IDrivenRouteRepository RouteRepository { get; set; }
        IAccountRepository AccountRepository { get; set; }
        IBusDrivenRouteRepository BusDrivenRoutesRepository { get; set; }
        ISeatRepository SeatRepository { get; set; }
        ITimeTableRepository TimeTableRepository { get; set; }
        Task SaveChangesAsync();
    }
}
