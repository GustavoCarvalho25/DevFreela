﻿using DevFreela.Application.Commands.Projects.CompleteProject;
using DevFreela.Application.Commands.Projects.DeleteProject;
using DevFreela.Application.Commands.Projects.InsertComment;
using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Application.Commands.Projects.StartProject;
using DevFreela.Application.Commands.Projects.UpdateProject;
using DevFreela.Application.Querys.Projects.GetAllProjects;
using DevFreela.Application.Querys.Projects.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET : api/projects?search=value
        [HttpGet]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> GetAll(string search = "", int page = 0, int size = 3)
        {
            var query = new GetAllProjectsQuery(search, page, size);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // GET : api/projects/1234
        [HttpGet("{id}")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProjectByIdQuery(id));

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST : api/projects
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Post(InsertProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, command);
        }

        // PUT : api/projects/1234
        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // Delete : api/projects/1234
        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // POST : api/projects/1234/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Start(int id)
        {
            var result = await _mediator.Send(new StartProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //PUT : api/projects/1234/complete
        [HttpPut("{id}/complete")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteProjectCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        //POST : api/projects/1234/comments
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> PostComment(int id, InsertCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
