using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ReservationRepository.AddReservation(request.Reservation);
            _unitOfWork.CustomerRepository.GetCustomerById(request.customerId).Reservations.Add(request.Reservation);
            return Unit.Value;
        }
    }
}
