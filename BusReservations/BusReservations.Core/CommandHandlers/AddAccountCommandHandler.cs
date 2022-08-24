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
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddAccountCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.AccountRepository.AddAccount(request.Account);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
