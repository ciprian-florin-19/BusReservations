using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var result = await _mediator.Send(new GetAccountByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<AccountGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllAccountsQuery { Index = index });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<IEnumerable<AccountGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddAcount([FromBody] AccountPutPostDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            var result = await _mediator.Send(new AddAccountCommand { Account = account });
            return CreatedAtAction(nameof(GetAccountById), new { Id = account.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountPutPostDto accountDto, Guid id)
        {
            var account = _mapper.Map<Account>(accountDto);
            var result = await _mediator.Send(new UpdateAccountCommand { Account = account, Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var result = await _mediator.Send(new DeleteAccountCommand { Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
