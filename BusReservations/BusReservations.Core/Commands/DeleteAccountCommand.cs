using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    public class DeleteAccountCommand : IRequest<Account>
    {
        public Guid Id { get; set; }
    }
}
