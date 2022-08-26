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
    internal class GetAllBusesQueryHandler : IRequestHandler<GetAllBusesQuery, IEnumerable<Bus>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllBusesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Bus>> Handle(GetAllBusesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusRepository.GetAllBuses(request.PageIndex);
        }
    }
}
