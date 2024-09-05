using DevFreela.Application.Commands.Skills.DeleteSkill;
using DevFreela.Application.Commands.Skills.InsertSkill;
using DevFreela.Application.Querys.Skills.GetSkillByDescription;
using DevFreela.Application.Querys.Skills.GetSkillById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetByDescription(string search = "", int page = 0, int pageSize = 3)
        {
            var query = new GetSkillByDescriptionQuery(search, page, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetSkillByIdQuery(Id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSkillCommand(id);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
