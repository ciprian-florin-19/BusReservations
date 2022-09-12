using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
using BusReservations.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Tests
{
    public class QueryHandlersTests
    {
        [Fact]
        public async Task Get_Bus_By_Id_Should_Call_GetBusById_Once()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            mockBusRepository.Setup(r => r.GetBusByID(It.IsAny<Guid>())).ReturnsAsync(new Bus());
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var handler = new GetBusByIDQueryHandler(mockUnitOfWork.Object);

            await handler.Handle(new Mock<GetBusByIDQuery>().Object, new CancellationToken());

            mockUnitOfWork.Verify(mock => mock.BusRepository.GetBusByID(It.IsAny<Guid>()), Times.Once());
        }

        [Fact]
        public async Task GetBusById_Returns_CorrectBus()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            var busId = Guid.NewGuid();
            mockBusRepository.Setup(r => r.GetBusByID(busId)).ReturnsAsync(new Bus { Id = busId });
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var handler = new GetBusByIDQueryHandler(mockUnitOfWork.Object);

            var result = await handler.Handle(new GetBusByIDQuery { BusID = busId }, new CancellationToken());

            Assert.Equal(busId, result.Id);
        }

        [Fact]
        public async Task GetBusById_Throws_NotFoundException_On_Invalid_BusId()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            var busId = Guid.NewGuid();
            mockBusRepository.Setup(r => r.GetBusByID(busId)).ReturnsAsync(new Bus { Id = busId });
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var handler = new GetBusByIDQueryHandler(mockUnitOfWork.Object);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(new GetBusByIDQuery { BusID = Guid.NewGuid() }, new CancellationToken()));
        }


    }
}
