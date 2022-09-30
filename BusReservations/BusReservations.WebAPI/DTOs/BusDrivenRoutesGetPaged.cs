using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;

namespace BusReservations.WebAPI.DTOs
{
    public class BusDrivenRoutesGetPaged
    {
        public PagedList<BusDrivenRouteGetDto> busDrivenRoutes { get; set; }
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }

        public bool HasNext => CurrentPage < PageCount;
        public bool HasPrevious => CurrentPage > 1;

        public BusDrivenRoutesGetPaged(PagedList<BusDrivenRoute> bdr, IMapper mapper)
        {
            busDrivenRoutes = mapper.Map<PagedList<BusDrivenRouteGetDto>>(bdr);
            CurrentPage = bdr.CurrentPage;
            PageCount = bdr.PageCount;
            PageSize = bdr.PageSize;
            if (busDrivenRoutes.Count < PageSize)
                PageSize = busDrivenRoutes.Count;
        }
    }
}
