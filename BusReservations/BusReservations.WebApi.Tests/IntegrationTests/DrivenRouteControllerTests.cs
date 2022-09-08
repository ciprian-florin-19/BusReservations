using BusReservations.Core.Domain;
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
    public class DrivenRouteControllerTests
    {
        private HttpClient? _client;
        private CustomWebApplicationFactory<Program> _factory;
        private string _urlBase = "api/v1/driven-routes/";
        public DrivenRouteControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Fact]
        public async Task GetDrivenRouteById_Returns_Correct_Route()
        {
            var routeId = "c44721d0-c3cd-4b44-933e-19905d8aed23";

            var response = await _client.GetAsync(_urlBase + routeId);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<DrivenRouteGetDto>(result);

            Assert.Equal("Pitesti", actualResult.Start);
            Assert.Equal("Sibiu", actualResult.Destination);
        }
        [Theory]
        [InlineData("bb775bb2-61c0-4f4f-9d39-53c9976c0d61", 2)]
        public async Task GetBusesByDrivenRoute_Returns_Paged_List(string routeId, int pageSize)
        {
            var uri = _urlBase + $"{routeId}/buses";

            var response = await _client.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<PagedList<BusSimpleDto>>(result).Count;

            Assert.Equal(pageSize, actualResult);
        }
        [Fact]
        public async Task GetAllRoutes_Returns_PagedList()
        {
            var expectedResult = new PaginationParameters().PageSize;

            var response = await _client.GetAsync(_urlBase);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<PagedList<DrivenRouteGetDto>>(result).Count;

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public async Task AddRoute_Returns_Created_Route()
        {
            var routeDto = new DrivenRoutePutPostDto
            {
                Start = "Testing Start",
                Destination = "Destination",
                SeatPrice = 35,
                TimeTable = new TimeTablePutPostDto
                {
                    DepartureDate = new DateTime(2022, 10, 12, 12, 30, 0),
                    ArivvalDate = new DateTime(2022, 10, 12, 14, 0, 0),
                }
            };

            var response = await _client.PostAsync(_urlBase,
                new StringContent(JsonConvert.SerializeObject(routeDto), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            Assert.Contains("Testing Start", result);
        }
        [Theory]
        [InlineData("c44721d0-c3cd-4b44-933e-19905d8aed23", HttpStatusCode.NoContent)]
        [InlineData("168ce709-471c-42be-9353-3ec85c084a45", HttpStatusCode.NotFound)]
        public async Task UpdateRoute_Returns_Corresponding_StatusCode(string routeToUpdateId, HttpStatusCode expectedCode)
        {
            var routeDto = new DrivenRoutePutPostDto
            {
                Start = "Updating Start",
                Destination = "Updating Destination",
                SeatPrice = 21,
                TimeTable = new TimeTablePutPostDto
                {
                    DepartureDate = new DateTime(2022, 10, 12, 12, 30, 0),
                    ArivvalDate = new DateTime(2022, 10, 12, 14, 0, 0),
                }
            };
            var uri = _urlBase + $"{routeToUpdateId}";

            var response = await _client.PutAsync(uri,
                new StringContent(JsonConvert.SerializeObject(routeDto), Encoding.UTF8, "application/json"));

            Assert.Equal(expectedCode, response.StatusCode);
        }
        [Theory]
        [InlineData("c44721d0-c3cd-4b44-933e-19905d8aed23", HttpStatusCode.NoContent)]
        [InlineData("168ce709-471c-42be-9353-3ec85c084a45", HttpStatusCode.NotFound)]
        public async Task DeleteRoute_Returns_Corresponding_StatusCode(string routeToDeleteId, HttpStatusCode expectedCode)
        {
            var uri = _urlBase + $"{routeToDeleteId}";

            var response = await _client.DeleteAsync(uri);

            Assert.Equal(expectedCode, response.StatusCode);
        }
    }
}
