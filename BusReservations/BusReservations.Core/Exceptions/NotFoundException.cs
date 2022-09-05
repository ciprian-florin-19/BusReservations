using BusReservations.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Exceptions
{
    public class NotFoundException : CustomHtttpException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public NotFoundException() : base("The requested item does not exist in the current context") { }

    }
}
