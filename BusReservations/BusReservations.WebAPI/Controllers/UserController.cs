﻿using AutoMapper;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.Core.QueryHandlers;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = id });
            if (result == null)
                return NotFound();
            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetAllUsersQuery { Index = index });
            if (result == null)
                return NoContent();
            var mappedResult = _mapper.Map<IEnumerable<UserGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserPutPostDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = await _mediator.Send(new AddUserCommand { User = mappedUser });
            return CreatedAtAction(nameof(GetUserById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserPutPostDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var result = await _mediator.Send(new UpdateUserCommand { Id = id, User = mappedUser });
            if (user == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });
            if (result == null)
                return NotFound();
            return NoContent();
        }

        [HttpGet("filter/{status}")]
        public async Task<IActionResult> GetUsersByStatus(Status status, [FromQuery] int index = 1)
        {
            var result = await _mediator.Send(new GetUsersByStatusQuery { Status = status, Index = index });
            if (result == null)
                return NoContent();
            var mappedUser = _mapper.Map<IEnumerable<UserGetDto>>(result);
            return Ok(mappedUser);
        }
    }
}