using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class GetDrivenRouteByIdQueryHandler : IRequestHandler<GetDrivenRouteByIdQuery, DrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public GetDrivenRouteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrivenRoute> Handle(GetDrivenRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var route = await _unitOfWork.RouteRepository.GetDrivenRouteById(request.Id);
            if (route == null)
                throw new NotFoundException();
            return route;
        }
    }
}
