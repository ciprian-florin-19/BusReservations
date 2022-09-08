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
    public class AddDrivenRouteCommandHandler : IRequestHandler<AddDrivenRouteCommand, DrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public AddDrivenRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrivenRoute> Handle(AddDrivenRouteCommand request, CancellationToken cancellationToken)
        {
            request.Route.TimeTable = new TimeTable(request.Route.TimeTable.DepartureDate, request.Route.TimeTable.ArivvalDate);
            _unitOfWork.RouteRepository.AddDrivenRoute(request.Route);
            await _unitOfWork.SaveChangesAsync();
            return request.Route;
        }
    }
}
