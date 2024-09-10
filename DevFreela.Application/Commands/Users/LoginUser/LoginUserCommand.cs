using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Users.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
