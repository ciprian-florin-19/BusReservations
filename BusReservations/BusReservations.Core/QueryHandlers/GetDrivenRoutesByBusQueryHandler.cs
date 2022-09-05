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
    public class GetDrivenRoutesByBusQueryHandler : IRequestHandler<GetDrivenRoutesByBusQuery, IEnumerable<DrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetDrivenRoutesByBusQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DrivenRoute>> Handle(GetDrivenRoutesByBusQuery request, CancellationToken cancellationToken)
        {
            var routes = await _unitOfWork.BusDrivenRoutesRepository.GetDrivenRoutesByBus(request.BusId);
            if (routes == null)
                throw new NotFoundException();
            return routes;
        }
    }
}
