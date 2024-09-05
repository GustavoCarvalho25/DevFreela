using DevFreela.Application.Commands.Projects.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class ProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public ProjectValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(50)
                    .WithMessage("Deve ter no máximo 50 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(100)
                    .WithMessage("Valor deve ser maior que 100.");
        }
    }
}
