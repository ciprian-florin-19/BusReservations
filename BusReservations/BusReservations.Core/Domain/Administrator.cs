using MediatR;

namespace BusReservations.Core.Domain
{
    internal class Administrator : User
    {
        public List<IRequest>? AvailableRequests { get; private set; }
    }
}
