using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    internal class AddCustomerCommand : IRequest
    {
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
