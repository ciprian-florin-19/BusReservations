using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Queries
{
    public class GetCustomerReservationsQuery : IRequest<IEnumerable<Reservation>>
    {
        public Guid CustomerId { get; set; }
        public int PageIndex { get; set; }
    }
}
