using MediatR;

namespace BusReservations.Core.Commands
{
    public class CancelReservationCommand : IRequest
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
