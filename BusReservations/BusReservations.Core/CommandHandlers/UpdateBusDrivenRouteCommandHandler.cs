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
    public class UpdateBusDrivenRouteCommandHandler : IRequestHandler<UpdateBusDrivenRouteCommand, BusDrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateBusDrivenRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BusDrivenRoute> Handle(UpdateBusDrivenRouteCommand request, CancellationToken cancellationToken)
        {
            var bdr = await _unitOfWork.BusDrivenRoutesRepository.GetBusDrivenRouteByID(request.Id);
            if (bdr == null)
                throw new NotFoundException();
            bdr.DrivenRouteId = request.newBdr.DrivenRouteId;
            bdr.BusId = request.newBdr.BusId;
            _unitOfWork.BusDrivenRoutesRepository.UpdateBusDrivenRoute(bdr);
            await _unitOfWork.SaveChangesAsync();
            return request.newBdr;
        }
    }
}
