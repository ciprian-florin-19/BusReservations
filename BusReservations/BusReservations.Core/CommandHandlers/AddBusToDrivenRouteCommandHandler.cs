using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.CommandHandlers
{
    public class AddBusToDrivenRouteCommandHandler : IRequestHandler<AddBusToDrivenRouteCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddBusToDrivenRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddBusToDrivenRouteCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.BusDrivenRoutesRepository.AddBusDrivenRoute(
                new BusDrivenRoute()
                {
                    Id = Guid.NewGuid(),
                    Bus = request.Bus,
                    BusId = request.Bus.Id,
                    DrivenRoute = request.DrivenRoute,
                    DrivenRouteId = request.DrivenRoute.Id
                }
                );
            return Unit.Value;
        }
    }
}
