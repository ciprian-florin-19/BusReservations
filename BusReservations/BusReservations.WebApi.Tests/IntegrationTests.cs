using BusReservations.Infrastructure.Data;
using BusReservations.WebAPI.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace BusReservations.WebApi.Tests
{
    public class IntegrationTests
    {
        private HttpClient? _client;
        private AppDBContext _context;
        private CustomWebApplicationFactory<Program> _factory;
        private string _urlBase = "api/v1/";
        public IntegrationTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Fact]
        public async Task GetBusById_Returns_Correct_Bus()
        {
            var busId = "buses/74cd2565-4101-4e4f-904d-2cb5eb924790";
            var expectedResult = "Vasile Transports";

            var response = await _client.GetAsync(_urlBase + busId);
            var result = await response.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<BusGetDto>(result);

            Assert.Equal(expectedResult, actualResult.Name);
        }
    }
}