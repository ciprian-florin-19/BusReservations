namespace BusReservations.Core.Pagination
{
    public class PaginationParameters
    {
        private int _maxPageSize = 20;
        private int _pageSize = 10;

        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < _maxPageSize)
                    _pageSize = value;
                else
                    _pageSize = _maxPageSize;
            }
        }
    }
}
