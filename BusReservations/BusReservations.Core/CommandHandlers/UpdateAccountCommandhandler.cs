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
    public class UpdateAccountCommandhandler : IRequestHandler<UpdateAccountCommand, Account>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateAccountCommandhandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.AccountRepository.GetAccountById(request.Id);
            if (toUpdate == null)
                throw new NotFoundException();
            toUpdate.User.Name = request.Account.User.Name;
            toUpdate.User.Email = request.Account.User.Email;
            toUpdate.User.PhoneNumber = request.Account.User.PhoneNumber;
            toUpdate.User.Status = request.Account.User.Status;
            toUpdate.Username = request.Account.Username;
            toUpdate.Password = request.Account.Password;
            toUpdate.HasAdminPrivileges = request.Account.HasAdminPrivileges;
            _unitOfWork.AccountRepository.UpdateAccount(toUpdate);
            await _unitOfWork.SaveChangesAsync();
            return toUpdate;
        }
    }
}
