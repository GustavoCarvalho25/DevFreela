using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Skills.UpdateSkill
{
    public class UpdateSkillCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public UpdateSkillCommand(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
