using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/buses")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public BusController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusById(Guid id)
        {
            var bus = await _mediator.Send(new GetBusByIDQuery { BusID = id });
            var result = _mapper.Map<BusGetDto>(bus);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBuses([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllBusesQuery() { PageIndex = index });
            var mappedResult = _mapper.Map<IEnumerable<BusGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] BusPutPostDto busDto)
        {
            var bus = _mapper.Map<Bus>(busDto);
            var result = await _mediator.Send(new AddBusCommand() { Bus = bus });
            return CreatedAtAction(nameof(GetBusById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBus(Guid id, [FromBody] BusPutPostDto newBus)
        {
            var bus = _mapper.Map<Bus>(newBus);
            var result = await _mediator.Send(new UpdateBusCommand() { NewBus = bus, Id = id });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(Guid id)
        {
            var result = await _mediator.Send(new DeleteBusCommand() { Id = id });
            return NoContent();
        }

        [HttpGet("{busId}/driven-routes")]
        public async Task<IActionResult> GetDrivenRoutesByBus(Guid busId)
        {
            var result = await _mediator.Send(new GetDrivenRoutesByBusQuery { BusId = busId });
            var mappedResult = _mapper.Map<ICollection<DrivenRouteSimpleDto>>(result);
            return Ok(mappedResult);
        }
    }
}
