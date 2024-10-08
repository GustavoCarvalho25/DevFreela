﻿using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.Projects.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsHandler(IProjectRepository projectRepository)
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
                .Select(p => ProjectItemViewModel.ConvertToViewModel(p))
                .ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(projectsViewModel);
        }
    }
}
