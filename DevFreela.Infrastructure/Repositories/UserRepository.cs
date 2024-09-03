using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await Task.FromResult(user.Id);
        }

        public async Task<bool> CheckUserExists(int id)
        {
            var userExist = await _context.Users.AnyAsync(u => u.Id == id);

            return userExist;

        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                .Include(us => us.Skills)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task AddUserSkills(List<UserSkill> skills)
        {
            await _context.UserSkills.AddRangeAsync(skills);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
