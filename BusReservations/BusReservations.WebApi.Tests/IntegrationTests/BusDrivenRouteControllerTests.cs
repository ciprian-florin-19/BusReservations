using BusReservations.Core.Pagination;
using BusReservations.WebAPI.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.WebApi.Tests.IntegrationTests
{
    public class BusDrivenRouteControllerTests
    {
        private HttpClient? _client;
        private CustomWebApplicationFactory<Program> _factory;
        private string _urlBase = "api/v1/bus-driven-routes/";
        public BusDrivenRouteControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Theory]
        [InlineData("9c525fa0-b3c8-4610-8819-e82f58dfe7e3", HttpStatusCode.OK)]
        [InlineData("db12076a-07a6-466e-b06c-f43e8d9e0612", HttpStatusCode.NotFound)]
        public async Task GetBusDrivenRouteById_Returns_Corresponding_StatusCode(string id, HttpStatusCode expectedCode)
        {

            var response = await _client.GetAsync(_urlBase + id);

            Assert.Equal(expectedCode, response.StatusCode);
        }
        [Fact]
        public async Task GetAvailableRides_Returns_Valid_BDR()
        {
            var uri = _urlBase + "available?start=Campulung&destination=Brasov&year=2022&month=09&day=22&index=1";
            var expectedResult = new PaginationParameters().PageSize;

            var response = await _client.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<PagedList<BusDrivenRouteGetDto>>(result).Count;

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
