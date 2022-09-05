using BusReservations.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Exceptions
{
    public class NoContentException : CustomHtttpException
    {
        public NoContentException() : base("No content available") { }
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NoContent;
    }
}
