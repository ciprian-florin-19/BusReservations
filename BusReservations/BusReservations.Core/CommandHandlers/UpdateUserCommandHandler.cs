using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.UserRepository.GetUserById(request.Id);
            if (toUpdate == null)
                throw new NotFoundException();
            toUpdate.Name = request.User.Name;
            toUpdate.PhoneNumber = request.User.PhoneNumber;
            toUpdate.Email = request.User.Email;
            toUpdate.Status = request.User.Status;
            _unitOfWork.UserRepository.UpdateUser(toUpdate);
            await _unitOfWork.SaveChangesAsync();
            return toUpdate;
        }
    }
}
