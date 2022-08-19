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
    public class GetBusesByDrivenRouteQueryHandler : IRequestHandler<GetBusesByDrivenRouteQuery, ICollection<Bus>>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusesByDrivenRouteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Bus>> Handle(GetBusesByDrivenRouteQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BusDrivenRoutesRepository.GetBusesByDrivenRoute(request.RouteId);
        }
    }
}
