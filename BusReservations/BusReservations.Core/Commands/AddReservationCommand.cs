using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class AddReservationCommand : IRequest<Reservation>
    {
        public Reservation Reservation { get; set; }
    }
}
