using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data
{
    public class AppDBContext
    {
        public List<Bus>? Buses { get; set; } = new List<Bus>();    
    }
}
