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
    internal class DeleteBusDrivenRouteCommandHandler : IRequestHandler<DeleteBusDrivenRouteCommand, BusDrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteBusDrivenRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BusDrivenRoute> Handle(DeleteBusDrivenRouteCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _unitOfWork.BusDrivenRoutesRepository.GetBusDrivenRouteByID(request.Id);
            if (toDelete == null)
                throw new NotFoundException();
            _unitOfWork.BusDrivenRoutesRepository.DeleteBusDrivenRoute(toDelete);
            await _unitOfWork.SaveChangesAsync();
            return toDelete;
        }
    }
}
