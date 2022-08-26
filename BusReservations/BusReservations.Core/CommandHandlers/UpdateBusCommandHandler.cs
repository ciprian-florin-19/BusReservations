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
            var toUpdate = _unitOfWork.BusRepository.GetBusByID(request.Id);
            if (toUpdate == null)
            {
                return null;
            }
            request.NewBus.Id = request.Id;
            _unitOfWork.BusRepository.UpdateBus(request.NewBus);
            await _unitOfWork.SaveChangesAsync();
            return request.NewBus;
        }
    }
}
