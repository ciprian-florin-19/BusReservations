using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetBusByIDQueryHandler : IRequestHandler<GetBusByIDQuery, Bus>
    {
        private IUnitOfWork _unitOfWork;

        public GetBusByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Bus> Handle(GetBusByIDQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusRepository.GetBusByID(request.BusID);
        }
    }
}
