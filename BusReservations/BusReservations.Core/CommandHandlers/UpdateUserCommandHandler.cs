using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.CommandHandlers
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.UserRepository.UpdateUser(request.User);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
