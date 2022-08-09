using BusReservations.Core.Abstract;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetAvailableSeatsQueryHandler : IRequestHandler<GetAvailableSeatsQuery, IEnumerable<int>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAvailableSeatsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<int>> Handle(GetAvailableSeatsQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.RouteRepository.GetAvailableSeats(request.RouteId);
        }
    }
}
