using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetAvailableRidesQueryHandler : IRequestHandler<GetAvailableRidesQuery, IEnumerable<BusDrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAvailableRidesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BusDrivenRoute>> Handle(GetAvailableRidesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BusDrivenRoutesRepository.GetAvailableRides(request.Start, request.Destination, request.DepartureDate, request.PageIndex);

        }
    }
}
