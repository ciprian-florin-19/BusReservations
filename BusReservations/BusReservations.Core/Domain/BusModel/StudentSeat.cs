using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain.BusModel
{
    public class StudentSeat : Seat
    {
        public override string? Type { get => "regular"; set => base.Type = value; }
        public override float Discount { get => 25; set => base.Discount = value; }
    }

}
