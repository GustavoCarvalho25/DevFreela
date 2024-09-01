using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<int> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddUserSkills(List<UserSkill> skills)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
