using MediatR;

namespace BusReservations.Core.Domain.Factory
{
    internal class Administrator : User
    {
        public List<IRequest>? AvailableRequests { get; private set; }
    }
}
