using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private AppDBContext _appDBContext;

        public TimeTableRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddTimeTable(TimeTable timeTable)
        {
            _appDBContext.TimeTables.Add(timeTable);
        }

        public void DeleteTimeTable(TimeTable timeTable)
        {
            _appDBContext.Remove(timeTable);
        }

        public async Task<IEnumerable<TimeTable>> GetAllTimeTables(int pageIndex = 1)
        {
            return await _appDBContext.TimeTables.ToPagedListAsync(pageIndex);
        }

        public async Task<TimeTable> GetTimeTableByID(Guid id)
        {
            var timeTable = await _appDBContext.TimeTables.SingleOrDefaultAsync(timetable => timetable.Id == id);
            return timeTable;
        }

        public void UpdateTimeTable(TimeTable timeTable)
        {
            _appDBContext.Update(timeTable);
        }
    }
}
