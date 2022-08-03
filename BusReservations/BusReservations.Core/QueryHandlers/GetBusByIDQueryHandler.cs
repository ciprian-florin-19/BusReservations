﻿using BusReservations.Core.Abstract;
using BusReservations.Core.Domain.BusModel;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetBusByIDQueryHandler : IRequestHandler<GetBusByIDQuery, Bus>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Bus> Handle(GetBusByIDQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BusRepository.GetBusByID(request.BusID);
        }
    }
}
