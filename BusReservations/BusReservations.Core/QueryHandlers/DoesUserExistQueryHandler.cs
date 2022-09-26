using BusReservations.Core.Abstract;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.QueryHandlers
{
    public class DoesUserExistQueryHandler : IRequestHandler<DoesUserExistQuery, User>
    {
        private IUnitOfWork _unitOfWork;

        public DoesUserExistQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(DoesUserExistQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.DoesUserExist(request.User);
            if (user == null)
                throw new NotFoundException();
            return user;
        }
    }
}
