using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetAllAccountsQuery : IRequest<IEnumerable<Account>>
    {
        public int Index { get; set; }
    }
}
