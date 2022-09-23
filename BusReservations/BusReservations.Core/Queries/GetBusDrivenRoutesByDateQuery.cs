using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetBusDrivenRoutesByDateQuery : IRequest<PagedList<BusDrivenRoute>>
    {
        public DateTime Date { get; set; }
        public int PageIndex { get; set; }
    }
}
