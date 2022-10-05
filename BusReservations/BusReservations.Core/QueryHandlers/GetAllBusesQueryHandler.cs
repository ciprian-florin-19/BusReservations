using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
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
    internal class GetAllBusesQueryHandler : IRequestHandler<GetAllBusesQuery, PagedList<Bus>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllBusesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Bus>> Handle(GetAllBusesQuery request, CancellationToken cancellationToken)
        {
            var buses = await _unitOfWork.BusRepository.GetAllBuses(request.PageIndex);
            if (buses == null || buses.Count() == 0)
                throw new NoContentException();
            return buses;
        }
    }
}
