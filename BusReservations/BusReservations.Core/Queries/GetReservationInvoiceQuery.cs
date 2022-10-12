using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetReservationInvoiceQuery : IRequest<byte[]>
    {
        public Guid Id { get; set; }
    }
}
