﻿using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    internal class UpdateAccountCommand : IRequest
    {
        public Account Account { get; set; }
    }
}
