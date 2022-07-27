using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain.BusModel
{
    internal class ElderlySeat:Seat
    {
        public override string? Type { get => "elderly"; set => base.Type = value; }
        public override float Discount { get => 50; set => base.Discount = value; }
    }
}
