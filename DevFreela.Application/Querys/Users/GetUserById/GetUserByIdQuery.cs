using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
