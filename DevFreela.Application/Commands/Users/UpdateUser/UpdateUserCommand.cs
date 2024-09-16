using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public UpdateUserCommand(int id, string fullName, string email, DateTime birthDate, string password, string role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
        }

        public void SetHashingInPassord(string hashingPassword)
        {
            Password = hashingPassword;
        }
    }
}
