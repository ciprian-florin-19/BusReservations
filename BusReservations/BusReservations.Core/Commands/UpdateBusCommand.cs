using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    public class UpdateBusCommand : IRequest<Bus>
    {
        public Guid Id { get; set; }
        public Bus NewBus { get; set; }
    }
}
