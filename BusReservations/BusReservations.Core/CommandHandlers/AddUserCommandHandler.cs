using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.AddUser(request.User);
            await _unitOfWork.SaveChangesAsync();
            return request.User;
        }
    }
}
