﻿using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    public class AddBusToDrivenRouteCommand : IRequest<BusDrivenRoute>
    {
        public Guid DrivenRouteId { get; set; }
        public Guid BusId { get; set; }
    }
}
