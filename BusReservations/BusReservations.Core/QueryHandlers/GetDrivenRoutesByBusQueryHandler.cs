using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
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
            return await _unitOfWork.BusDrivenRoutesRepository.GetDrivenRoutesByBus(request.BusId);
        }
    }
}
