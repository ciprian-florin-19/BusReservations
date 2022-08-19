using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain
{
    public class BusDrivenRoute
    {
        public Guid Id { get; set; }
        public Bus Bus { get; set; }
        public Guid BusId { get; set; }
        public DrivenRoute DrivenRoute { get; set; }
        public Guid DrivenRouteId { get; set; }
    }
}
