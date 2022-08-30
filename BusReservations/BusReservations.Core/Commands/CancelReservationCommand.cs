using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class CancelReservationCommand : IRequest<Reservation>
    {
        public Guid Id { get; set; }
    }
}
