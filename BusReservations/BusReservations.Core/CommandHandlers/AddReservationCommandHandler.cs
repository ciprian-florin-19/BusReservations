using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Domain.SeatModel;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, Reservation>
    {
        private IUnitOfWork _unitOfWork;

        public AddReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(request.Reservation.UserId);
            var route = await _unitOfWork.BusDrivenRoutesRepository.GetBusDrivenRouteByID(request.Reservation.BusDrivenRouteId);
            var seat = new Seat(request.Reservation.Seat.SeatNumber, request.Reservation.Seat.Type);
            if (route == null || user == null || seat == null)
                return null;
            var toAdd = new Reservation(user, route, seat);
            _unitOfWork.ReservationRepository.AddReservation(toAdd);
            await _unitOfWork.SaveChangesAsync();
            return toAdd;
        }
    }
}
