namespace BusReservations.Core.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }

        public bool HasNext => CurrentPage < PageCount;
        public bool HasPrevious => CurrentPage > 1;

        public PagedList(IEnumerable<T> collection, PaginationParameters parameters)
        {
            CurrentPage = parameters.PageIndex;
            PageSize = parameters.PageSize;
            PageCount = (int)Math.Ceiling(collection.Count() / (double)PageSize);
            AddRange(collection.Skip((parameters.PageIndex - 1) * PageSize).Take(PageSize));
        }

    }
}
