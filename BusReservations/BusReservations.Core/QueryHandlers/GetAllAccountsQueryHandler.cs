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
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllAccountsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AccountRepository.GetAllAccounts(request.Index);
        }
    }
}
