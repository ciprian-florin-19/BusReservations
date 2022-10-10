using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Pagination;
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
            var mappedResult = _mapper.Map<ICollection<BusSimpleDto>>(result);
            return Ok(mappedResult);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrivenRouteById(Guid id)
        {
            var result = await _mediator.Send(new GetDrivenRouteByIdQuery { Id = id });
            var mappedResult = _mapper.Map<DrivenRouteSimpleDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivenRoutes([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllDrivenRoutesQuery { Index = index });
            var mappedResult = _mapper.Map<PagedList<DrivenRouteSimpleDto>>(result);
            return Ok(new PagedListGetDto<DrivenRouteSimpleDto>(mappedResult, new PaginationParametersDto
            {
                CurrentPage = index,
                PageCount = result.PageCount,
                PageSize = result.PageSize,
                TotalElementCount = result.TotalElementCount
            }));
        }
        [HttpPost]
        public async Task<IActionResult> AddDrivenRoute([FromBody] DrivenRoutePutPostDto routeDto)
        {
            var route = _mapper.Map<DrivenRoute>(routeDto);
            var result = await _mediator.Send(new AddDrivenRouteCommand { Route = route });
            return CreatedAtAction(nameof(GetDrivenRouteById), new { Id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrivenRoute([FromBody] DrivenRoutePutPostDto routeDto, Guid id)
        {
            var route = _mapper.Map<DrivenRoute>(routeDto);
            var result = await _mediator.Send(new UpdateRouteCommand { Id = id, Route = route });
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrivenRoute(Guid id)
        {
            var result = await _mediator.Send(new DeleteRouteCommand { Id = id });
            return NoContent();
        }
    }
}
