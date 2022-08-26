using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class AddBusCommand : IRequest<Bus>
    {
        public Bus Bus { get; set; }
    }
}
