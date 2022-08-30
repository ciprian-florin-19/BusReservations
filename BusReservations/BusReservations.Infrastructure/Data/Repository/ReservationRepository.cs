using Azure.Core;
using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private AppDBContext _appDBContext;

        public ReservationRepository(AppDBContext addDBContext)
        {
            _appDBContext = addDBContext ?? throw new ArgumentNullException(nameof(AppDBContext));
        }

        public void AddRange(IEnumerable<Reservation> reservations)
        {
            _appDBContext.Reservations.AddRange(reservations);
        }

        public void AddReservation(Reservation reservation)
        {
            _appDBContext.Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _appDBContext.Reservations.Remove(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations(int pageIndex = 1)
        {
            return await _appDBContext.Reservations
                .Include(r => r.User)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.Bus)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.DrivenRoute)
                .Include(r => r.Seat)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(r => r.DrivenRoute.TimeTable)
                .ToPagedListAsync(pageIndex);
        }

        public async Task<IEnumerable<Reservation>> getCustomerReservations(Guid customerId, int pageIndex = 1)
        {
            return await _appDBContext.Reservations
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.Bus)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.DrivenRoute)
                .Include(r => r.Seat)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(r => r.DrivenRoute.TimeTable)
                .Where(item => item.User.Id == customerId).ToPagedListAsync(pageIndex);
        }

        public async Task<Reservation> GetReservationById(Guid id)
        {
            var reservation = await _appDBContext.Reservations
                .Include(r => r.User)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.Bus)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(bdr => bdr.DrivenRoute)
                .Include(r => r.Seat)
                .Include(r => r.BusDrivenRoute)
                .ThenInclude(r => r.DrivenRoute.TimeTable)
                .SingleOrDefaultAsync(reservation => reservation.Id == id);
            return reservation;
        }

        public void UpdateReservation(Reservation reservation)
        {
            _appDBContext.Update(reservation);
        }
    }
}
