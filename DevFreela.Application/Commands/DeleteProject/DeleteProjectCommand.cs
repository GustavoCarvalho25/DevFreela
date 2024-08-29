using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
