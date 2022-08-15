using BusReservations.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void GetBusById_Should_Return_Bus()
        {
            var mockContext = new Mock<IDbContext>();
            var bus = new Bus
            {
                Id = Guid.NewGuid(),
                Capacity = 10,
                Name = "Vasile Transports"
            };
            mockContext.SetupGet(mock => mock.Buses).Returns(new List<Bus> { bus });
            var repository = new BusRepository(mockContext.Object);

            var result = repository.GetBusByID(bus.Id);

            Assert.Equal(bus, result);
        }

        [Fact]
        public void DeleteBus_Should_Delete_Bus()
        {
            var mockContext = new Mock<IDbContext>();
            var bus = new Bus
            {
                Id = Guid.NewGuid(),
                Capacity = 10,
                Name = "Vasile Transports"
            };
            mockContext.SetupGet(mock => mock.Buses).Returns(new List<Bus> { bus });
            var repository = new BusRepository(mockContext.Object);
            var expected = mockContext.Object.Buses.Count - 1;

            repository.DeleteBus(bus.Id);

            Assert.Equal(expected, mockContext.Object.Buses.Count);
        }
    }
}
