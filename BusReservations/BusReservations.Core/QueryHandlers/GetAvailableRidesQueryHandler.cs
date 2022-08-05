using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetAvailableRidesQueryHandler : IRequestHandler<GetAvailableRidesQuery, IEnumerable<DrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAvailableRidesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DrivenRoute>> Handle(GetAvailableRidesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.RouteRepository.GetAvailableRides(request.Start, request.Destination, request.DepartureDate, request.PageIndex);
        }
    }
}
