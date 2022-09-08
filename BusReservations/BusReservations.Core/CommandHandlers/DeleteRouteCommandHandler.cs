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
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, DrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrivenRoute> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var route = await _unitOfWork.RouteRepository.GetDrivenRouteById(request.Id);
            if (route == null)
                throw new NotFoundException();
            _unitOfWork.RouteRepository.DeleteDrivenRoute(route);
            await _unitOfWork.SaveChangesAsync();
            return route;
        }
    }
}
