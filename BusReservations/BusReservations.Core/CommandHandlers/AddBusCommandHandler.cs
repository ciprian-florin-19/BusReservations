using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;

namespace BusReservations.Core.CommandHandlers
{
    public class AddBusCommandHandler : IRequestHandler<AddBusCommand, Bus>
    {

        private IUnitOfWork _unitOfWork;

        public AddBusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Bus> Handle(AddBusCommand request, CancellationToken cancellationToken)
        {
            var bus = request.Bus;
            _unitOfWork.BusRepository.AddBus(bus);
            await _unitOfWork.SaveChangesAsync();
            return bus;
        }
    }
}
