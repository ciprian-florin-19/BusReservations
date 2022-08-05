using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class AddBusCommand : IRequest
    {
        public Bus Bus { get; set; }
    }
}
