using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetBusesByDrivenRouteQuery : IRequest<ICollection<Bus>>
    {
        public Guid RouteId { get; set; }
    }
}
