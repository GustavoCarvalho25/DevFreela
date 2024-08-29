using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Querys.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllProjectsQueryHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(
            GetAllProjectsQuery request,
            CancellationToken cancellationToken)
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted && (request.Search == "" || p.Title.Contains(request.Search) || p.Description.Contains(request.Search)))
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            var projectsViewModel = projects
                .Select(p => ProjectItemViewModel.FromEntity(p))
                .ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(projectsViewModel);
        }
    }
}
