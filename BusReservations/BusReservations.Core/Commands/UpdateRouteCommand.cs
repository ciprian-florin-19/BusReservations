using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class UpdateRouteCommand : IRequest<DrivenRoute>
    {
        public DrivenRoute Route { get; set; }
        public Guid Id { get; set; }
    }
}
