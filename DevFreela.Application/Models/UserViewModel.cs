using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class UserViewModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; }

        public UserViewModel(string fullName, string email, DateTime birthDate, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
        }

        public static UserViewModel FromEntity(User user)
        {
            var skills = user.Skills.Select(us => us.Skill.Description).ToList();
            return new UserViewModel(user.FullName, user.Email, user.BirthDate, skills);
        }
    }
}
