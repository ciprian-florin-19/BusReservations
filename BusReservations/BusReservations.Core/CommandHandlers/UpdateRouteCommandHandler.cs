using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateRouteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.RouteRepository.UpdateDrivenRoute(request.Id, request.NewRoute);
            return Unit.Value;
        }
    }
}
