using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetByDescription(string search, int page, int size);
        Task<Skill?> GetById(int id);
        Task Update(Skill skill);
        Task Delete(Skill skill);
        Task Add(Skill skill);
        Task<bool> CheckIfSkillExistsById(int id);
    }
}
