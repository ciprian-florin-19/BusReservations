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
    public class GetAllDrivenRoutesQueryHandler : IRequestHandler<GetAllDrivenRoutesQuery, IEnumerable<DrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllDrivenRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DrivenRoute>> Handle(GetAllDrivenRoutesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RouteRepository.GetAllDrivenRoutes(request.Index);
        }
    }
}
