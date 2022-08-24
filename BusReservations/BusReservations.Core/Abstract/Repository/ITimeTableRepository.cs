using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface ITimeTableRepository
    {
        void AddTimeTable(TimeTable timeTable);
        Task<IEnumerable<TimeTable>> GetAllTimeTables(int pageIndex = 1);
        Task<TimeTable> GetTimeTableByID(Guid id);
        void UpdateTimeTable(TimeTable timeTable);
        void DeleteTimeTable(TimeTable timeTable);
    }
}
