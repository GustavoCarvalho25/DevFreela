using DevFreela.Application.Commands.Users.InsertUser;
using DevFreela.Application.Commands.Users.InsertUserSkills;
using DevFreela.Application.Commands.Users.LoginUser;
using DevFreela.Application.Commands.Users.UpdateUser;
using DevFreela.Application.Querys.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET : api/users
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST : api/users
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT : api/users/1234
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST : api/users/1/skills
        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int userId, InsertUserSkillsCommand command)
        {

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // PUT : api/users/1/profile-picture
        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile picture)
        {
            var description = $"File: {picture.Name}, Size: {picture.Length}";

            return Ok(description);
        }

        // PUT : api/users/login
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
