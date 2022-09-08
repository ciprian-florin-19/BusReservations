using BusReservations.Core.Pagination;
using BusReservations.Infrastructure.Data;
using BusReservations.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace BusReservations.WebApi.Tests
{
    public class BusControllerTests
    {
        private HttpClient? _client;
        private CustomWebApplicationFactory<Program> _factory;
        private string _urlBase = "api/v1/buses/";
        public BusControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Fact]
        public async Task GetBusById_Returns_Correct_Bus()
        {
            var busId = "74cd2565-4101-4e4f-904d-2cb5eb924790";
            var expectedResult = "Vasile Transports";

            var response = await _client.GetAsync(_urlBase + busId);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<BusGetDto>(result);

            Assert.Equal(expectedResult, actualResult.Name);
        }
        [Fact]
        public async Task GetAllBuses_Returns_PagedList()
        {
            var expectedResult = new PaginationParameters().PageSize;

            var response = await _client.GetAsync(_urlBase);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<PagedList<BusGetDto>>(result).Count;

            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public async Task AddBus_Returns_Created_Bus()
        {
            var busDto = new BusPutPostDto
            {
                Name = "New Bus",
                Capacity = 31
            };

            var response = await _client.PostAsync(_urlBase,
                new StringContent(JsonConvert.SerializeObject(busDto), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            Assert.Contains("New Bus", result);
        }
        [Theory]
        [InlineData("74cd2565-4101-4e4f-904d-2cb5eb924790", HttpStatusCode.NoContent)]
        [InlineData("168ce709-471c-42be-9353-3ec85c084a45", HttpStatusCode.NotFound)]
        public async Task UpdateBus_Returns_Corresponding_StatusCode(string busToUpdateId, HttpStatusCode expectedCode)
        {
            var busDto = new BusPutPostDto
            {
                Name = "Updated Bus",
                Capacity = 31
            };
            var uri = _urlBase + $"{busToUpdateId}";

            var response = await _client.PutAsync(uri,
                new StringContent(JsonConvert.SerializeObject(busDto), Encoding.UTF8, "application/json"));

            Assert.Equal(expectedCode, response.StatusCode);
        }
        [Theory]
        [InlineData("74cd2565-4101-4e4f-904d-2cb5eb924790", HttpStatusCode.NoContent)]
        [InlineData("168ce709-471c-42be-9353-3ec85c084a45", HttpStatusCode.NotFound)]
        public async Task DeleteBus_Returns_Corresponding_StatusCode(string busToDeleteId, HttpStatusCode expectedCode)
        {
            var uri = _urlBase + $"{busToDeleteId}";

            var response = await _client.DeleteAsync(uri);

            Assert.Equal(expectedCode, response.StatusCode);
        }
        [Theory]
        [InlineData("74cd2565-4101-4e4f-904d-2cb5eb924790", 2)]
        [InlineData("cdecd2eb-4a6f-4300-b89d-d4e1e8d0ee22", 0)]
        public async Task GetDrivenRoutesByBus_Returns_Paged_List(string busId, int pageSize)
        {
            var uri = _urlBase + $"{busId}/driven-routes";

            var response = await _client.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<PagedList<BusGetDto>>(result).Count;

            Assert.Equal(pageSize, actualResult);
        }
    }
}