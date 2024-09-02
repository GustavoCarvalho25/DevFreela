using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkills
{
    public class InsertUserSkillsCommand : IRequest<ResultViewModel<int>>
    {
        public int[] SkillIds { get; set; }
        public int IdUser { get; set; }

        public InsertUserSkillsCommand(int[] skillIds, int idUser)
        {
            SkillIds = skillIds;
            IdUser = idUser;
        }
    }
}
