using AutoMapper;
using BusReservations.Core.Domain;
using BusReservations.Core.Queries;
using BusReservations.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusReservations.WebAPI.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IMediator _mediator;
        private IMapper _mapper;

        public AuthenticationController(UserManager<Account> userManager, RoleManager<IdentityRole> roleManager, IMediator mediator, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = await _userManager.FindByNameAsync(username);
            if (account != null && await _userManager.CheckPasswordAsync(account, password))
            {
                var roles = await _userManager.GetRolesAsync(account);

                var claims = new List<Claim>();

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("014257c5-7702-432f-b89f-68913e69fdcc"));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7124/",
                    audience: "http://localhost:4200/",
                    claims: claims,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AccountPutPostDto accountDto)
        {

            var accountExists = await _userManager.FindByNameAsync(accountDto.UserName);


            if (accountExists != null)
                return BadRequest("Account already exists!");

            var account = _mapper.Map<Account>(accountDto);

            var user = _mapper.Map<User>(accountDto.User);

            User userDataExists;

            IdentityResult result;

            try
            {
                userDataExists = await _mediator.Send(new DoesUserExistQuery { User = user });
                account.User = userDataExists;
            }
            catch (Exception ex)
            {
                Console.WriteLine("user data duplication prevented");
            }
            finally
            {
                result = await _userManager.CreateAsync(account, account.Password);
            }

            if (!result.Succeeded)
                return BadRequest("Failed to create account!");

            return Ok("Account created successfully");
        }

        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AddToRole(string username, string roleName)
        {
            var accountExists = await _userManager.FindByNameAsync(username);

            if (accountExists == null)
                return BadRequest("Account already exists!");

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }

            var result = await _userManager.AddToRoleAsync(accountExists, roleName);

            if (!result.Succeeded)
                return BadRequest("Failed to add user to role!");

            return Ok($"{username} is now {roleName}");
        }
    }
}
