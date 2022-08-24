using BusReservations.Core;
using BusReservations.Core.Domain.SeatModel;
using Microsoft.EntityFrameworkCore;
using SeatReservations.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly AppDBContext _appDBContext;

        public SeatRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddSeat(Seat seat)
        {
            _appDBContext.Seats.Add(seat);
        }

        public void DeleteSeat(Seat seat)
        {
            _appDBContext.Seats.Remove(seat);
        }

        public async Task<IEnumerable<Seat>> GetAllSeats(int pageIndex = 1)
        {
            return await _appDBContext.Seats.ToPagedListAsync();
        }

        public async Task<Seat> GetSeatByID(Guid id)
        {
            var seat = await _appDBContext.Seats.SingleOrDefaultAsync(seat => seat.Id == id);
            return seat;
        }

        public void UpdateSeat(Seat seat)
        {
            _appDBContext.Update(seat);
        }
    }
}
