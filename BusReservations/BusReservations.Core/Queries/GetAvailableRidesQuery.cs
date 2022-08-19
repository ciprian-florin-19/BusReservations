using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Queries
{
    public class GetAvailableRidesQuery : IRequest<IEnumerable<BusDrivenRoute>>
    {
        public string Start { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PageIndex { get; set; }
    }
}
