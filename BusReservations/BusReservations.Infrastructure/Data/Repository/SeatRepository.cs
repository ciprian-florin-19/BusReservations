using BusReservations.Core;
using BusReservations.Core.Domain.SeatModel;
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
            _appDBContext.SaveChanges();
        }

        public void DeleteSeat(Guid id)
        {
            _appDBContext.Seats.Remove(GetSeatByID(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<Seat> GetAllSeats(int pageIndex = 1)
        {
            return _appDBContext.Seats.ToPagedList();
        }

        public Seat GetSeatByID(Guid id)
        {
            return _appDBContext.Seats.FirstOrDefault(seat => seat.Id == id);
        }

        public void UpdateSeat(Guid id, Seat newSeat)
        {
            var seat = GetSeatByID(id);
            if (seat != null)
            {
                seat = newSeat;
                _appDBContext.SaveChanges();
            }
        }
    }
}
