using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CompleteProject
{
    public class CompleteProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
