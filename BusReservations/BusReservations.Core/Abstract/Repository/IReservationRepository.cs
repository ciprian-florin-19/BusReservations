using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IReservationRepository
    {
        public void AddReservation(Reservation reservation);
        public IEnumerable<Reservation> GetAllReservations();   
    }
}
