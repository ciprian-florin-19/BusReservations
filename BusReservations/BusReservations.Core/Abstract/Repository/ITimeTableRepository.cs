using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface ITimeTableRepository
    {
        void AddTimeTable(TimeTable timeTable);
        IEnumerable<TimeTable> GetAllTimeTables(int pageIndex = 1);
        TimeTable GetTimeTableByID(Guid id);
        void UpdateTimeTable(Guid id, TimeTable newTimeTable);
        void DeleteTimeTable(Guid id);
    }
}
