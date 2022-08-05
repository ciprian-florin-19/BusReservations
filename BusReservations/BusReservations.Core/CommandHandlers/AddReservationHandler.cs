using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    internal class AddReservationHandler : IRequestHandler<AddReservationCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ReservationRepository.AddReservation(request.Reservation);
            return Unit.Value;
        }
    }
}
