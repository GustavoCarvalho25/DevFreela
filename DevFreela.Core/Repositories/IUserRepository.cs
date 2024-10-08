﻿using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<int> Add(User user);
        Task Update(User user);
        Task AddUserSkills(List<UserSkill> skills);
        Task<bool> CheckUserExists(int id);
        Task<User?> GetUserByEmailAndPassword(string email, string passwordEncrypted);
    }
}
