using BusReservations.Core.Abstract;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.CommandHandlers
{
    internal class UpdateBusCommandHandler : IRequestHandler<UpdateBusCommand, Bus>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateBusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Bus> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.BusRepository.GetBusByID(request.Id);
            if (toUpdate == null)
            {
                return null;
            }
            toUpdate.Name = request.NewBus.Name;
            toUpdate.Capacity = request.NewBus.Capacity;
            _unitOfWork.BusRepository.UpdateBus(toUpdate);
            await _unitOfWork.SaveChangesAsync();
            return toUpdate;
        }
    }
}
