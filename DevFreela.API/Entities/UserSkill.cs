namespace DevFreela.API.Entities
{
    public class UserSkill : BaseEntity
    {
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdSkill { get; private set; }
        public Skill Skill { get; private set; }

        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }
    }
}
