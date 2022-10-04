using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using BusReservations.Core.Exceptions;
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
                throw new NotFoundException();
            _unitOfWork.ReservationRepository.DeleteReservation(toDelete);
            _unitOfWork.SeatRepository.DeleteSeat(toDelete.Seat);
            toDelete.BusDrivenRoute.OccupiedSeats.Remove(toDelete.Seat);
            await _unitOfWork.SaveChangesAsync();
            return toDelete;
        }
    }
}
