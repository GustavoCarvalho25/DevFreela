using DevFreela.Application.Commands.Users.InsertUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<InsertUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Nome é obrigatório.")
                .MaximumLength(30)
                    .WithMessage("Nome deve ter no máximo 30 caracteres.");

            RuleFor(u => u.Email)
                .EmailAddress()
                    .WithMessage("E-mail inválido.");

            RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Data de nascimento inválida.");


        }
    }
}
