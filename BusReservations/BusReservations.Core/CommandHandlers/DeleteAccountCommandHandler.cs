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
    internal class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.DeleteAccount(request.Id);
            return Unit.Value;
        }
    }
}
