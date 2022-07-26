﻿using BusReservations.Core.Abstract;
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
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<Reservation>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.ReservationRepository.GetAllReservations(request.Index);
            if (reservations == null || reservations.Count() == 0)
                throw new NoContentException();
            return reservations;
        }
    }
}
