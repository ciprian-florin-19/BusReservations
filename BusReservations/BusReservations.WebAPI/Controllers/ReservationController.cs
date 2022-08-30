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
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<ReservationGetDto>(result);
            return Ok(mappedResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReservations([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllReservationsQuery { Index = index });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<IEnumerable<ReservationGetDto>>(result);
            return Ok(mappedResult);
        }
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationPutPostDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var result = await _mediator.Send(new AddReservationCommand { Reservation = reservation });
            return CreatedAtAction(nameof(GetReservationById), new { Id = result.Id }, result);
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
