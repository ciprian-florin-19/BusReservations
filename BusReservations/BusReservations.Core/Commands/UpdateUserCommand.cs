﻿using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Commands
{
    internal class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public User NewUser { get; set; }
    }
}
