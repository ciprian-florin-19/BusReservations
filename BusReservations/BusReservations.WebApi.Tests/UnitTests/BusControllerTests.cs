using AutoMapper;
using BusReservations.Core;
using BusReservations.Core.Domain;
using BusReservations.Core.Exceptions;
using BusReservations.Core.Pagination;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.WebApi.Tests.UnitTests
{
    public class BusControllerTests
    {
        private Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        public BusControllerTests()
        {
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllBusesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
        }

        [Fact]
        public async Task GetBusById_Calls_GetBusByIdQuery_Once()
        {
            _mockMediator.Setup(m => m.Send(It.IsAny<GetBusByIDQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            var controller = new BusController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetBusById(It.IsAny<Guid>());

            _mockMediator.Verify(m => m.Send(It.IsAny<GetBusByIDQuery>(), It.IsAny<CancellationToken>())
            , Times.Once);
        }

        [Fact]
        public async Task GetBusById_Returns_Correct_Bus()
        {
            var actualResult = Guid.NewGuid();
            var expectedResult = Guid.NewGuid();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetBusByIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetBusByIDQuery, CancellationToken>(async (q, c) =>
                {
                    actualResult = q.BusID;
                    return await Task.FromResult(new Bus
                    { });
                });

            var controller = new BusController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetBusById(expectedResult);

            Assert.Equal(actualResult, expectedResult);
        }

        [Fact]
        public async Task GetBusById_Throws_NotFoundException_When_BusId_Is_Invalid()
        {
            var invalidId = Guid.NewGuid();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetBusByIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetBusByIDQuery, CancellationToken>(async (q, c) =>
                {
                    var validId = Guid.NewGuid();
                    if (q.BusID != validId)
                        throw new NotFoundException();
                    return await Task.FromResult(new Bus
                    { });
                });
            var controller = new BusController(_mockMediator.Object, _mockMapper.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => controller.GetBusById(invalidId));
        }

        [Fact]
        public async Task GetAllBuses_Calls_GetAllBusesQuery_Once()
        {
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllBusesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            var controller = new BusController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetAllBuses();

            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllBusesQuery>(), It.IsAny<CancellationToken>())
            , Times.Once);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        public async Task GetAllBuses_Returns_Correct_Buses_Page(int index)
        {
            var actualResult = 0;
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllBusesQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetAllBusesQuery, CancellationToken>(async (q, c) =>
                {
                    actualResult = q.PageIndex;
                    return await new List<Bus>
                    { }.ToPagedListAsync(q.PageIndex);
                });
            var controller = new BusController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetAllBuses(index);

            Assert.Equal(index, actualResult);
        }
    }
}
