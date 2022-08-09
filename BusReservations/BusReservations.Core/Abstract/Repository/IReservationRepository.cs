using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        IEnumerable<Reservation> GetAllReservations(int pageIndex = 1);
        Reservation GetReservationById(Guid id);
        void UpdateReservation(Guid reservationId, Reservation newReservation);
        void DeleteReservation(Guid reservationId);
        IEnumerable<Reservation> getCustomerReservations(Guid customerId, int pageIndex = 1);
    }
}
