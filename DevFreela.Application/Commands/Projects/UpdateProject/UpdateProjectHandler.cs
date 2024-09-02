using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.IdProject);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Update(request.Title, request.Description, request.TotalCost);

            await _projectRepository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
