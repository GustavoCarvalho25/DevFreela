using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.Projects.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
