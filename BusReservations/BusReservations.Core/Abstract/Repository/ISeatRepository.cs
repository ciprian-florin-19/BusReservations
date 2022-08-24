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
        Task<IEnumerable<Seat>> GetAllSeats(int pageIndex = 1);
        Task<Seat> GetSeatByID(Guid SeatId);
        void UpdateSeat(Seat seat);
        void DeleteSeat(Seat seat);
    }
}
