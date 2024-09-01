using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public InsertCommentHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var exists = await _projectRepository.Exists(request.IdProject);

            if (!exists)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            var projectComment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectRepository.AddComment(projectComment);

            return ResultViewModel.Success();
        }
    }
}
