using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkillViewModel
    {   
        public int Id { get; set; }
        public string Description { get; set; }

        public SkillViewModel(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public static SkillViewModel ConvertToViewModel(Skill skill)
        => new SkillViewModel(skill.Id, skill.Description);
    }
}
