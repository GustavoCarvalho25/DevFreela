using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Querys.Skills.GetSkillByDescription
{
    public class GetByDescriptionHandler :
        IRequestHandler<GetSkillByDescriptionQuery,
            ResultViewModel<List<SkillViewModel>>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetByDescriptionHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ResultViewModel<List<SkillViewModel>>> Handle(GetSkillByDescriptionQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetByDescription(
                    search: request.DescriptionSearch,
                    page: request.Page,
                    size: request.PageSize
                );

            var skillsViewModels = skills.Select(s => SkillViewModel.ConvertToViewModel(s))
                .ToList();

            return ResultViewModel<List<SkillViewModel>>.Success(skillsViewModels);
        }
    }
}
