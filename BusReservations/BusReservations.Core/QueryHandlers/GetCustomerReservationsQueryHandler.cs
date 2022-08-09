﻿using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetCustomerReservationsQueryHandler : IRequestHandler<GetCustomerReservationsQuery, IEnumerable<Reservation>>
    {
        private IUnitOfWork _unitOfWork;

        public GetCustomerReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Reservation>> Handle(GetCustomerReservationsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.CustomerRepository.GetCustomerById(request.CustomerId).Reservations.ToPagedList(request.PageIndex);
        }
    }
}
