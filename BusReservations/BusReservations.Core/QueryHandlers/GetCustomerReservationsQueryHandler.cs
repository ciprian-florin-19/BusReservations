using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Pagination;
using BusReservations.Core.Queries;
using MediatR;

namespace BusReservations.Core.QueryHandlers
{
    public class GetCustomerReservationsQueryHandler : IRequestHandler<GetCustomerReservationsQuery, PagedList<Reservation>>
    {
        private IUnitOfWork _unitOfWork;

        public GetCustomerReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<Reservation>> Handle(GetCustomerReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.ReservationRepository.getCustomerReservations(request.CustomerId, request.PageIndex);
            if (reservations == null || reservations.Count() == 0)
                throw new NoContentException();
            return reservations;
        }
    }
}
