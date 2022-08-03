﻿using BusReservations.Core.Domain.BusModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetBusByIDQuery : IRequest<Bus>
    {
        public Guid BusID { get; set; }
    }
}
