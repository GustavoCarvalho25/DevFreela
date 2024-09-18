using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }

        public InsertUserCommand(
            string fullName,
            string email,
            DateTime birthDate,
            string password,
            string role)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
        }

        public User ToEntity()
        => new User(FullName, Email, BirthDate, Password, Role);

        public void SetHashingInPassord(string hashingPassword)
        {
            Password = hashingPassword;
        }
    }
}
