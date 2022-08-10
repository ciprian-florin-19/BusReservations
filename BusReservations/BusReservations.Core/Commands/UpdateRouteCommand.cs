using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class UpdateRouteCommand : IRequest
    {
        public Guid Id { get; set; }
        public DrivenRoute NewRoute { get; set; }
    }
}
