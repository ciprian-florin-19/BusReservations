using BusReservations.Core.Pagination;

namespace BusReservations.Core
{
    public static class Extensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values)
        {
            return new PagedList<T>(values.ToList(), new PaginationParameters());
        }
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values, int pageSize, int pageIndex = 1)
        {
            return new PagedList<T>(values.ToList(), new PaginationParameters() { PageSize = pageSize, PageIndex = pageIndex });
        }
    }
}
