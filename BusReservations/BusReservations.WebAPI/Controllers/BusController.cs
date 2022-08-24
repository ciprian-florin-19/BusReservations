using AutoMapper;
using BusReservations.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

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
            return Ok(bus);
        }
    }
}
