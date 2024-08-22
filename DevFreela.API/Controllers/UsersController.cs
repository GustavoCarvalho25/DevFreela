using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;

        public UsersController(DevFreelaDbContext context)
        {
            _context = context;
        }

        // GET : api/users
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Skills)
                .ThenInclude(us => us.Skill)
                .SingleOrDefault(u => u.Id == id);

            if(user is null)
            {
                return NotFound();
            }

            var model = UserViewModel.FromEntity(user);

            return Ok(model);
        }

        // POST : api/users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        // POST : api/users/1/skills
        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id, UserSkillsCreateInputModel model)
        {
            var userSkills = model.SkillIds
                .Select(s => new UserSkill(id, s))
                .ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return NoContent();
        }

        // PUT : api/users/1/profile-picture
        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile picture)
        {
            var description = $"File: {picture.Name}, Size: {picture.Length}";

            return Ok(description);
        }
    }
}
