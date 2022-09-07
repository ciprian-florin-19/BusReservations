using BusReservations.Core.Abstract.Repository;
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
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var getBusByIdQuery = new Mock<GetBusByIDQuery>();
            getBusByIdQuery.SetupGet(q => q.BusID).Returns(It.IsAny<Guid>());
            var handler = new GetBusByIDQueryHandler(mockUnitOfWork.Object);

            await handler.Handle(getBusByIdQuery.Object, new CancellationToken());

            mockUnitOfWork.Verify(mock => mock.BusRepository.GetBusByID(It.IsAny<Guid>()), Times.Once());
        }
    }
}
