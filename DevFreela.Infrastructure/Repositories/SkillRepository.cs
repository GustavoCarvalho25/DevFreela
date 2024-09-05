using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfSkillExistsById(int id)
        {
            var exists = await _context.Skills.AnyAsync(s => s.Id == id);
            
            return exists;
        }

        public async Task Delete(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetByDescription(string search, int page, int size)
        {
            var skills = await _context.Skills
                .Where(s => s.Description.Contains(search))
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            return skills;
        }

        public async Task<Skill?> GetById(int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }
    }
}
