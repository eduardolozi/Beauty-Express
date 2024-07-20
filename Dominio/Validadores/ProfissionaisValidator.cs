using FluentValidation;
using Modelos.Profissional;

namespace Dominio.Validadores;

public class ProfissionaisValidator : AbstractValidator<Profissional>
{
    public ProfissionaisValidator()
    {
        RuleFor(c => c.Nome)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome deve ser preenchido");

        RuleFor(c => c.Especialidade)
            .NotNull()
            .NotEmpty()
            .WithMessage("Especialidade deve ser preenchido");
    }
}