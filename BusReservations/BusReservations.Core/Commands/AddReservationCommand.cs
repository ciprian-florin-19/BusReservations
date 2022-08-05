using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    internal class AddReservationCommand : IRequest
    {
        public Reservation Reservation { get; set; }
    }
}
