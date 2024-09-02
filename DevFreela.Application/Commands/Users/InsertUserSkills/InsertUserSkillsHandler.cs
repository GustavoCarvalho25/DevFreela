using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkills
{
    public class InsertUserSkillsHandler : IRequestHandler<InsertUserSkillsCommand, ResultViewModel<int>>
    {
        private readonly IUserRepository _repository;

        public InsertUserSkillsHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserSkillsCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.CheckUserExists(request.IdUser);

            if (!exists)
            {
                return ResultViewModel<int>.Error("Usuário não existe.");
            }

            var userSkills = request.SkillIds.Select(s =>
            new UserSkill(request.IdUser, s)).ToList();

            await _repository.AddUserSkills(userSkills);

            return ResultViewModel<int>.Success(request.IdUser);
        }
    }
}
