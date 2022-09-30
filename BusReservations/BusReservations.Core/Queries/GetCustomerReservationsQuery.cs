using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using MediatR;

namespace BusReservations.Core.Queries
{
    public class GetCustomerReservationsQuery : IRequest<PagedList<Reservation>>
    {
        public Guid CustomerId { get; set; }
        public int PageIndex { get; set; }
    }
}
