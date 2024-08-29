using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
