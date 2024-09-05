using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.Skills.GetSkillById
{
    public class GetSkillByIdQuery : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public GetSkillByIdQuery(int id)
        {
            Id = id;
        }
    }
}
