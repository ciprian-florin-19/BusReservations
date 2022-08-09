using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    internal class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.CustomerRepository.AddCustomer(new Customer(request.User, request.Status));
            return Unit.Value;
        }
    }
}
