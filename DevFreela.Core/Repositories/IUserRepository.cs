using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetDetailsById(int id);
        Task<int> Add(User user);
        Task Update(User user);
        Task PostSkills(UserSkill skills);
        Task<bool> Exists(int id);
    }
}
