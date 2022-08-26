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
    [Route("[controller]")]
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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBusById(Guid id)
        {
            var bus = await _mediator.Send(new GetBusByIDQuery { BusID = id });
            if (bus == null)
                return NotFound();
            var result = _mapper.Map<BusGetDto>(bus);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBuses([FromQuery] int pageIndex = 1)
        {
            var result = await _mediator.Send(new GetAllBusesQuery() { PageIndex = pageIndex });
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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBus(Guid id, [FromBody] BusPutPostDto newBus)
        {
            var bus = _mapper.Map<Bus>(newBus);
            var result = await _mediator.Send(new UpdateBusCommand() { NewBus = bus, Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBus(Guid id)
        {
            var result = await _mediator.Send(new DeleteBusCommand() { Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
