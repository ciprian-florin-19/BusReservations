using BusReservations.Core.Abstract;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class GetReservationInvoiceQueryHandler : IRequestHandler<GetReservationInvoiceQuery, byte[]>
    {
        private IUnitOfWork _unitOfWork;

        public GetReservationInvoiceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> Handle(GetReservationInvoiceQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.ReservationRepository.GetReservationById(request.Id);
            if (reservation == null)
                throw new NotFoundException();
            return reservation.ToPdf().BinaryData;
        }
    }
}
