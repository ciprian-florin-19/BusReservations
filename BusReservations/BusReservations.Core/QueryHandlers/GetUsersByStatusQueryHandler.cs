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
    public class GetUsersByStatusQueryHandler : IRequestHandler<GetUsersByStatusQuery, IEnumerable<User>>
    {
        private IUnitOfWork _unitOfWork;

        public GetUsersByStatusQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersByStatusQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetUsersByStatus(request.Status, request.Index);
            if (users == null || users.Count() == 0)
                throw new NoContentException();
            return users;
        }
    }
}
