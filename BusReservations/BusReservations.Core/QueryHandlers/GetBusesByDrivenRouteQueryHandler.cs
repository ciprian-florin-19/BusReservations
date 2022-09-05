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
    public class GetBusesByDrivenRouteQueryHandler : IRequestHandler<GetBusesByDrivenRouteQuery, ICollection<Bus>>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusesByDrivenRouteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Bus>> Handle(GetBusesByDrivenRouteQuery request, CancellationToken cancellationToken)
        {
            var buses = await _unitOfWork.BusDrivenRoutesRepository.GetBusesByDrivenRoute(request.RouteId);
            if (buses == null || buses.Count() == 0)
                throw new NoContentException();
            return buses;
        }
    }
}
