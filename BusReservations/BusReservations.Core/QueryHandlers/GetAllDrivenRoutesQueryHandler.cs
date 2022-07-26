﻿using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Pagination;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class GetAllDrivenRoutesQueryHandler : IRequestHandler<GetAllDrivenRoutesQuery, PagedList<DrivenRoute>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllDrivenRoutesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<DrivenRoute>> Handle(GetAllDrivenRoutesQuery request, CancellationToken cancellationToken)
        {
            var drivenRoutes = await _unitOfWork.RouteRepository.GetAllDrivenRoutes(request.Index);
            if (drivenRoutes == null || drivenRoutes.Count() == 0)
                throw new NoContentException();
            return drivenRoutes;
        }
    }
}
