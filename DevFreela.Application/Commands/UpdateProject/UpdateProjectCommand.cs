using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<ResultViewModel>
    {
        public int IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }

        public UpdateProjectCommand(int idProject, string title, string description, decimal totalCost)
        {
            IdProject = idProject;
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
