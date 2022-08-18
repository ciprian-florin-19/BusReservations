using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatReservations.Core.Abstract.Repository
{
    public interface ISeatRepository
    {
        void AddSeat(Seat seat);
        IEnumerable<Seat> GetAllSeats(int pageIndex = 1);
        Seat GetSeatByID(Guid SeatId);
        void UpdateSeat(Guid id, Seat newSeat);
        void DeleteSeat(Guid id);
    }
}
