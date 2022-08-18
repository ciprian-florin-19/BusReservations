using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    internal class AddUserCommand : IRequest
    {
        public User User { get; set; }
    }
}
