using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class UserViewModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Role { get; private set; }
        public List<string> Skills { get; private set; }

        public UserViewModel(string fullName, string email, DateTime birthDate, string role, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Role = role;
            Skills = skills;
        }

        public static UserViewModel ConvertToViewModel(User user)
        {
            var skills = user.Skills.Select(us => us.Skill.Description).ToList();
            return new UserViewModel(user.FullName, user.Email, user.BirthDate, user.Role, skills);
        }
    }
}
