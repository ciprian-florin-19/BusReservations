using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using BusReservations.WebAPI.DTOs;

namespace BusReservations.WebAPI.DTOs
{
    public class PagedListGetDto<T>
    {
        public PagedList<T> Items { get; set; }
        public PaginationParametersDto PaginationParameters { get; set; } = new PaginationParametersDto();

        public PagedListGetDto(PagedList<T> items, PaginationParametersDto pagination)
        {
            Items = items;
            PaginationParameters.CurrentPage = pagination.CurrentPage;
            PaginationParameters.PageCount = pagination.PageCount;
            PaginationParameters.PageSize = pagination.PageSize;
            //if (Items.Count < PaginationParameters.PageSize)
            //    PaginationParameters.PageSize = Items.Count;
            PaginationParameters.TotalElementCount = pagination.TotalElementCount;
        }
    }
}