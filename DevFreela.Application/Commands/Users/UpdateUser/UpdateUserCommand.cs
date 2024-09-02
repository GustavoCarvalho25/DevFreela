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

        public UpdateUserCommand(int id, string fullName, string email, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
