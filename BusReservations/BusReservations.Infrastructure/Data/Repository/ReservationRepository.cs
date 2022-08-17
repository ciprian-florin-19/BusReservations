using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data.Repository
{
    internal class ReservationRepository : IReservationRepository
    {
        private AppDBContext _appDBContext;

        public ReservationRepository(AppDBContext addDBContext)
        {
            _appDBContext = addDBContext ?? throw new ArgumentNullException(nameof(AppDBContext));
        }

        public void AddReservation(Reservation reservation)
        {
            _appDBContext.Reservations.Add(reservation);
            _appDBContext.SaveChanges();
        }

        public void DeleteReservation(Guid id)
        {
            _appDBContext.Reservations.Remove(GetReservationById(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetAllReservations(int pageIndex = 1)
        {
            return _appDBContext.Reservations.ToPagedList(pageIndex);
        }

        public IEnumerable<Reservation> getCustomerReservations(Guid customerId, int pageIndex = 1)
        {
            return _appDBContext.Reservations.Where(item => item.CustomerId == customerId).ToPagedList(pageIndex);
        }

        public Reservation GetReservationById(Guid id)
        {
            return _appDBContext.Reservations.FirstOrDefault(reservation => reservation.Id == id);
        }

        public void UpdateReservation(Guid id, Reservation newReservation)
        {
            var reservation = GetReservationById(id);
            if (reservation != null)
            {
                reservation = newReservation;
                _appDBContext.SaveChanges();
            }
        }
    }
}
