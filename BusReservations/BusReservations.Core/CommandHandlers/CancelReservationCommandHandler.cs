using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand, Reservation>
    {
        private IUnitOfWork _unitOfWork;
        public CancelReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _unitOfWork.ReservationRepository.GetReservationById(request.Id);
            if (toDelete == null)
                return null;
            _unitOfWork.ReservationRepository.DeleteReservation(toDelete);
            await _unitOfWork.SaveChangesAsync();
            return toDelete;
        }
    }
}
