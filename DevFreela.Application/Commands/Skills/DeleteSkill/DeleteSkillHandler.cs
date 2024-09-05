using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Skills.DeleteSkill
{
    public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, ResultViewModel>
    {
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetById(request.Id);

            if(skill is null)
            {
                return ResultViewModel.Error("Skill não existe.");
            }

            await _skillRepository.Delete(skill);

            return ResultViewModel.Success();
        }
    }
}
