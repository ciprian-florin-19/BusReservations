using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using IronPdf;

namespace BusReservations.Core
{
    public static class Extensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values)
        {
            return new PagedList<T>(values, new PaginationParameters());
        }
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values, int pageSize, int pageIndex = 1)
        {
            return new PagedList<T>(values, new PaginationParameters() { PageSize = pageSize, PageIndex = pageIndex });
        }
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values, int pageIndex = 1)
        {
            return new PagedList<T>(values, new PaginationParameters() { PageIndex = pageIndex });
        }
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IEnumerable<T> values, int pageIndex = 1)
        {
            return await PagedList<T>.Create(values, new PaginationParameters() { PageIndex = pageIndex });
        }

        public static PdfDocument ToPdf(this Reservation reservation)
        {
            return TicketUtilities.Instance.ConvertToPdf(reservation);
        }
    }
}
