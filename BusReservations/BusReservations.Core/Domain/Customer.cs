using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain
{
    public class Customer:User
    {
        public List<Reservation>? Reservations { get; set; }
    }
}
