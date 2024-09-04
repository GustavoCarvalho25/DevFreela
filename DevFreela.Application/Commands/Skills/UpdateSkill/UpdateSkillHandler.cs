using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Skills.UpdateSkill
{
    public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, ResultViewModel>
    {
        private readonly ISkillRepository _skillRepository;

        public UpdateSkillHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetById(request.Id);

            if (skill == null)
            {
                return ResultViewModel.Error("Skill não existe.");
            }

            await _skillRepository.Update(skill);

            return ResultViewModel.Success();
        }
    }
}
