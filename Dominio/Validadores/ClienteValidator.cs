using FluentValidation;
using Modelos.Cliente;

namespace Dominio.Validadores;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(c => c.Nome)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome deve ser preenchido");

        RuleFor(c => c.Telefone)
            .NotNull()
            .NotEmpty()
            .WithMessage("Telefone deve ser preenchido");

        RuleFor(c => c.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email deve ser preenchido");

        RuleFor(c => c.Senha)
            .NotNull()
            .NotEmpty()
            .WithMessage("Senha deve ser preenchido");
    }
}