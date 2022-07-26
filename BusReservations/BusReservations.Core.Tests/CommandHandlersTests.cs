﻿using BusReservations.Core.Abstract.Repository;
using BusReservations.Infrastructure.Data;
using BusReservations.Infrastructure.Data.Repository;

namespace BusReservations.Core.Tests
{
    public class CommandHandlersTests
    {
        [Fact]
        public async Task Add_Bus_Should_Call_Add_Method_Once()
        {
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var addBusCommand = new AddBusCommand();
            var handler = new AddBusCommandHandler(mockUnitOfWork.Object);
            //act
            await handler.Handle(addBusCommand, new CancellationToken());
            //assert
            mockUnitOfWork.Verify(mock => mock.BusRepository.AddBus(It.IsAny<Bus>()), Times.Once);
        }

        [Fact]
        public async Task AddBus_Returns_Added_Bus()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);

            var busToAdd = new Bus();
            var addBusCommand = new AddBusCommand() { Bus = busToAdd };
            var handler = new AddBusCommandHandler(mockUnitOfWork.Object);

            var result = await handler.Handle(addBusCommand, new CancellationToken());

            Assert.Equal(busToAdd, result);
        }
    }
}
