using BusReservations.Core.Domain.BusModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    public class AddBusCommand : IRequest
    {
        public Bus Bus { get; set; }
    }
}
