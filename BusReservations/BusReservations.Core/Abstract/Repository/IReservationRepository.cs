using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservations(int pageIndex = 1);
        Task<Reservation> GetReservationById(Guid id);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> getCustomerReservations(Guid customerId, int pageIndex = 1);
        void AddRange(IEnumerable<Reservation> reservations);
    }
}
