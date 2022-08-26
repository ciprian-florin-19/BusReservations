using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("[controller]")]
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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBusDrivenRouteById(Guid id)
        {
            var result = await _mediator.Send(new GetBusDrivenRouteByIdQuery() { Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<BusDrivenRouteGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        [Route("BusDrivenRoute")]
        public async Task<IActionResult> AddBusToDrivenRoute(Guid busId, Guid routeId)
        {
            var result = await _mediator.Send(new AddBusToDrivenRouteCommand() { BusId = busId, DrivenRouteId = routeId });
            var mappedResult = _mapper.Map<BusDrivenRouteGetDto>(result);
            if (result == null)
                return NotFound();
            return CreatedAtAction(nameof(GetBusDrivenRouteById), new { Id = mappedResult.Id }, mappedResult);
        }
    }
}
