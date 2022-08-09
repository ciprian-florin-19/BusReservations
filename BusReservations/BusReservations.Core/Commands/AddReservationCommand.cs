using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class AddReservationCommand : IRequest
    {
        public Reservation Reservation { get; set; }
        public Guid customerId { get; set; }
    }
}
