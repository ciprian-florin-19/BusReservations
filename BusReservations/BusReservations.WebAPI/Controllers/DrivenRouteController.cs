using AutoMapper;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/driven-routes")]
    [ApiController]
    public class DrivenRouteController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public DrivenRouteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}/buses")]
        public async Task<IActionResult> GetBusesByDrivenRoute(Guid id)
        {
            var result = await _mediator.Send(new GetBusesByDrivenRouteQuery { RouteId = id });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<ICollection<BusSimpleDto>>(result);
            return Ok(mappedResult);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrivenRouteById(Guid id)
        {
            var result = await _mediator.Send(new GetDrivenRouteByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<DrivenRouteGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivenRoutes([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllDrivenRoutesQuery { Index = index });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<IEnumerable<DrivenRouteGetDto>>(result);
            return Ok(mappedResult);
        }
        //[HttpPost]
        // public async Task<IActionResult> AddDrivenRoute([FromBody])
    }
}
