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
    public class AddBusToDrivenRouteCommandHandler : IRequestHandler<AddBusToDrivenRouteCommand, BusDrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public AddBusToDrivenRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BusDrivenRoute> Handle(AddBusToDrivenRouteCommand request, CancellationToken cancellationToken)
        {
            var bus = await _unitOfWork.BusRepository.GetBusByID(request.BusId);
            var route = await _unitOfWork.RouteRepository.GetDrivenRouteById(request.DrivenRouteId);
            if (bus == null || route == null)
                return null;
            var busDrivenRoute = new BusDrivenRoute()
            {
                Id = Guid.NewGuid(),
                Bus = bus,
                BusId = request.BusId,
                DrivenRoute = route,
                DrivenRouteId = request.DrivenRouteId
            };
            _unitOfWork.BusDrivenRoutesRepository.AddBusDrivenRoute(busDrivenRoute);
            await _unitOfWork.SaveChangesAsync();
            return busDrivenRoute;
        }
    }
}
