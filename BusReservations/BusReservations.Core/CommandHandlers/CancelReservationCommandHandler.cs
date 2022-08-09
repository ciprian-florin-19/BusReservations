﻿using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
    {
        private IUnitOfWork _unitOfWork;
        public CancelReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.CustomerRepository.GetCustomerById(request.CustomerId).Reservations.Remove(_unitOfWork.ReservationRepository.GetReservationById(request.ReservationId));
            _unitOfWork.ReservationRepository.DeleteReservation(request.ReservationId);
            return Unit.Value;
        }
    }
}
