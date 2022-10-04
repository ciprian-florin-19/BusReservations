using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public ReservationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            var result = await _mediator.Send(new GetReservationByIdQuery { Id = id });
            var mappedResult = _mapper.Map<ReservationSimpleGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReservations([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllReservationsQuery { Index = index });
            var mappedResult = _mapper.Map<IEnumerable<ReservationSimpleGetDto>>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationPutPostDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var result = await _mediator.Send(new AddReservationCommand { Reservation = reservation });
            var mappedResult = _mapper.Map<ReservationSimpleGetDto>(result);
            return CreatedAtAction(nameof(GetReservationById), new { Id = result.Id }, mappedResult);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var result = await _mediator.Send(new CancelReservationCommand { Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
