using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/bus-driven-routes")]
    [ApiController]
    public class BusDrivenRouteController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public BusDrivenRouteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusDrivenRouteById(Guid id)
        {
            var result = await _mediator.Send(new GetBusDrivenRouteByIdQuery() { Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<BusDrivenRouteGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> AddBusToDrivenRoute(Guid busId, Guid routeId)
        {
            var result = await _mediator.Send(new AddBusToDrivenRouteCommand() { BusId = busId, DrivenRouteId = routeId });
            var mappedResult = _mapper.Map<BusDrivenRouteGetDto>(result);
            if (result == null)
                return NotFound();
            return CreatedAtAction(nameof(GetBusDrivenRouteById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusDrivenRoute(Guid id, [FromBody] BusDrivenRoutePutPostDto bdr)
        {
            var newBdr = _mapper.Map<BusDrivenRoute>(bdr);
            var result = await _mediator.Send(new UpdateBusDrivenRouteCommand { Id = id, newBdr = newBdr });
            if (result == null)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusDrivenRoute(Guid id)
        {
            var result = await _mediator.Send(new DeleteBusDrivenRouteCommand { Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRides([FromQuery] string start, [FromQuery] string destination, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAvailableRidesQuery
            {
                Start = start,
                Destination = destination,
                DepartureDate = new DateTime(year, month, day),
                PageIndex = index
            });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<IEnumerable<BusDrivenRouteGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
