using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            return Ok();
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id, UserSkillsCreateInputModel model)
        {
            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile picture)
        {
            var description = $"File: {picture.Name}, Size: {picture.Length}";

            return Ok(description);
        }
    }
}
