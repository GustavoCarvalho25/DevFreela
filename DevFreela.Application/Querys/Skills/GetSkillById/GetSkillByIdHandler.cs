using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.Skills.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, ResultViewModel>
    {
        private readonly ISkillRepository _skillRepository;

        public GetSkillByIdHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ResultViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetById(id: request.Id);

            if (skill == null)
            {
                return ResultViewModel.Error("Skill não existe.");
            }

            var model = SkillViewModel.ConvertToViewModel(skill);

            return ResultViewModel<SkillViewModel>.Success(model);
        }
    }
}
