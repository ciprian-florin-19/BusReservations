﻿using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Queries
{
    public class GetAllDrivenRoutesQuery : IRequest<IEnumerable<DrivenRoute>>
    {
        public int Index { get; set; }
    }
}
