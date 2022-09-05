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
    internal class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Account>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _unitOfWork.AccountRepository.GetAccountById(request.Id);
            if (toDelete == null)
                throw new NotFoundException();
            _unitOfWork.AccountRepository.DeleteAccount(toDelete);
            _unitOfWork.UserRepository.DeleteUser(toDelete.User);
            await _unitOfWork.SaveChangesAsync();
            return toDelete;
        }
    }
}
