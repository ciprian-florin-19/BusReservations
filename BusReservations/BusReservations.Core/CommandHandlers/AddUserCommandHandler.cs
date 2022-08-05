using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.AddUser(request.User);
            return Unit.Value;
        }
    }
}
