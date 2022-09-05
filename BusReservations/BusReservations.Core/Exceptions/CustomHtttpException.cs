using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Abstract
{
    public abstract class CustomHtttpException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }
        public CustomHtttpException(string message) : base(message) { }
    }
}
