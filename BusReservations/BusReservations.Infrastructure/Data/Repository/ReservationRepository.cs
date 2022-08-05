using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data.Repository
{
    internal class ReservationRepository : IReservationRepository
    {
        private AppDBContext _addDBContext;

        public ReservationRepository(AppDBContext addDBContext)
        {
            _addDBContext = addDBContext ?? throw new ArgumentNullException(nameof(AppDBContext));
        }

        public void AddReservation(Reservation reservation)
        {
            _addDBContext.Reservations.Add(reservation);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _addDBContext.Reservations.ToPagedList();
        }
    }
}
