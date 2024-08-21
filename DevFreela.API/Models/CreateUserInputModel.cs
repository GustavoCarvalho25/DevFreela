
namespace DevFreela.API.Models
{
    public class CreateUserInputModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
