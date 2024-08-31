using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(
            GetAllProjectsQuery request,
            CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAll(
                request.Search,
                request.Page,
                request.Size);

            var projectsViewModel = projects
                .Select(p => ProjectItemViewModel.FromEntity(p))
                .ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(projectsViewModel);
        }
    }
}
