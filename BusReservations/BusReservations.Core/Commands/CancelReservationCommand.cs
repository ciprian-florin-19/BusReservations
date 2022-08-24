using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class CancelReservationCommand : IRequest
    {
        public Reservation Reservation { get; set; }
    }
}
