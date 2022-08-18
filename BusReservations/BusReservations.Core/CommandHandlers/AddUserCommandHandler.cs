using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.CustomerRepository.AddUser(request.User);
            return Unit.Value;
        }
    }
}
