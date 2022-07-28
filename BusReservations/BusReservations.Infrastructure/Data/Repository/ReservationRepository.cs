using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    internal class ReservationRepository : IReservationRepository
    {
        private AppDBContext _addDBContext;

        public ReservationRepository(AppDBContext addDBContext)
        {
            _addDBContext = addDBContext?? throw new ArgumentNullException(nameof(AppDBContext));
        }

        public void AddReservation(Reservation reservation)
        {
            _addDBContext.Reservations.Add(reservation);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _addDBContext.Reservations.ToList();
        }
    }
}
