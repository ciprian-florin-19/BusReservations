using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class GetBusDrivenRoutesByQueryHandler : IRequestHandler<GetBusDrivenRoutesByDateQuery, PagedList<BusDrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusDrivenRoutesByQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<BusDrivenRoute>> Handle(GetBusDrivenRoutesByDateQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusDrivenRoutesRepository.GetBusDrivenRoutesByDate(request.Date, request.PageIndex);
        }
    }
}
