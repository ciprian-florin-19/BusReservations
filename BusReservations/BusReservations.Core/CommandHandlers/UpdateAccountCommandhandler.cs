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
    internal class UpdateAccountCommandhandler : IRequestHandler<UpdateAccountCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateAccountCommandhandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.UpdateAccount(request.Account);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
