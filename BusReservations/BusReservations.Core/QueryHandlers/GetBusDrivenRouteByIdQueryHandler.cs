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
    public class GetBusDrivenRouteByIdQueryHandler : IRequestHandler<GetBusDrivenRouteByIdQuery, BusDrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusDrivenRouteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BusDrivenRoute> Handle(GetBusDrivenRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BusDrivenRoutesRepository.GetBusDrivenRouteByID(request.Id);
            if (result == null)
                throw new NotFoundException();
            return result;
        }
    }
}
