using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.Skills.GetSkillByDescription
{
    public class GetSkillByDescriptionQuery : IRequest<ResultViewModel<List<SkillViewModel>>>
    {
        public string DescriptionSearch { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetSkillByDescriptionQuery(string descriptionSearch, int page, int pageSize)
        {
            DescriptionSearch = descriptionSearch;
            Page = page;
            PageSize = pageSize;
        }
    }
}
