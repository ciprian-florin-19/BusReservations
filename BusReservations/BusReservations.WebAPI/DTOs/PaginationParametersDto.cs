namespace BusReservations.WebAPI.DTOs
{
    public class PaginationParametersDto
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }

        public bool HasNext => CurrentPage < PageCount;
        public bool HasPrevious => CurrentPage > 1;
    }
}
