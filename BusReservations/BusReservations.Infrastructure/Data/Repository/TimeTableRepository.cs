using BusReservations.Core;
using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
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
            _appDBContext.SaveChanges();
        }

        public void DeleteTimeTable(Guid id)
        {
            _appDBContext.Remove(GetTimeTableByID(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<TimeTable> GetAllTimeTables(int pageIndex = 1)
        {
            return _appDBContext.TimeTables.ToPagedList(pageIndex);
        }

        public TimeTable GetTimeTableByID(Guid id)
        {
            return _appDBContext.TimeTables.FirstOrDefault(timetable => timetable.Id == id);
        }

        public void UpdateTimeTable(Guid id, TimeTable newTimeTable)
        {
            var timeTable = GetTimeTableByID(id);
            if (timeTable != null)
            {
                timeTable = newTimeTable;
                _appDBContext.SaveChanges();
            }
        }
    }
}
