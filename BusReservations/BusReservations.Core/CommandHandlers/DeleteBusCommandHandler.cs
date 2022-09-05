using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.CommandHandlers
{
    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusCommand, Bus>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteBusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Bus> Handle(DeleteBusCommand request, CancellationToken cancellationToken)
        {
            var bus = await _unitOfWork.BusRepository.GetBusByID(request.Id);
            if (bus == null)
                throw new NotFoundException();
            _unitOfWork.BusRepository.DeleteBus(bus);
            await _unitOfWork.SaveChangesAsync();
            return bus;
        }
    }
}
