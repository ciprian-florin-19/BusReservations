using MediatR;

namespace BusReservations.Core.Queries
{
    public class GetAvailableSeatsQuery : IRequest<IEnumerable<int>>
    {
        public Guid RouteId { get; set; }
    }
}
