using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class UpdateRouteCommand : IRequest
    {
        public DrivenRoute Route { get; set; }
    }
}
