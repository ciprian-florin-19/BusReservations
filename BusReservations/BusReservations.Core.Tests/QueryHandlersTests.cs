using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
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
        public void Get_Bus_By_Id_Should_Call_GetBusById_Once()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockBusRepository = new Mock<IBusRepository>();
            mockUnitOfWork.SetupGet(mock => mock.BusRepository).Returns(mockBusRepository.Object);
            var getBusByIdQuery = new GetBusByIDQuery();
            var handler = new GetBusByIDQueryHandler(mockUnitOfWork.Object);

            handler.Handle(getBusByIdQuery, new CancellationToken());

            mockUnitOfWork.Verify(mock => mock.BusRepository.GetBusByID(It.IsAny<Guid>()), Times.Once());
        }
    }
}
