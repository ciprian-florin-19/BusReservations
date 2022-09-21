﻿using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class GetAllBusDrivenRoutesQueryHandler : IRequestHandler<GetAllBusDrivenRoutesQuery, IEnumerable<BusDrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllBusDrivenRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BusDrivenRoute>> Handle(GetAllBusDrivenRoutesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BusDrivenRoutesRepository.GetAllBusDrivenRoutes(request.pageIndex);
        }
    }
}
