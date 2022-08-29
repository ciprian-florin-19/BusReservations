using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
