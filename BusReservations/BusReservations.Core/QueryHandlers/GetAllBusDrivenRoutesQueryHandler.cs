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
    public class GetAllBusDrivenRoutesQueryHandler : IRequestHandler<GetAllBusDrivenRoutesQuery, PagedList<BusDrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllBusDrivenRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<BusDrivenRoute>> Handle(GetAllBusDrivenRoutesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusDrivenRoutesRepository.GetAllBusDrivenRoutes(request.pageIndex);
        }
    }
}
