using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, DrivenRoute>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrivenRoute> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.RouteRepository.GetDrivenRouteById(request.Id);
            if (toUpdate == null)
                throw new NotFoundException();
            toUpdate.Start = request.Route.Start;
            toUpdate.Destination = request.Route.Destination;
            toUpdate.SeatPrice = request.Route.SeatPrice;
            toUpdate.TimeTable.DepartureDate = request.Route.TimeTable.DepartureDate;
            toUpdate.TimeTable.ArivvalDate = request.Route.TimeTable.ArivvalDate;
            toUpdate.TimeTable.Duration = request.Route.TimeTable.ArivvalDate - request.Route.TimeTable.DepartureDate;

            _unitOfWork.RouteRepository.UpdateDrivenRoute(toUpdate);

            await _unitOfWork.SaveChangesAsync();
            return toUpdate;
        }
    }
}
