using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validadores;

public class EstabelecimentosValidator : AbstractValidator<Estabelecimento>
{
    public EstabelecimentosValidator()
    {
        RuleFor(c => c.Nome)
            .NotNull()
            .NotEmpty()
            .WithMessage("Nome deve ser preenchido");

        RuleFor(c => c.Telefone)
            .NotNull()
            .NotEmpty()
            .WithMessage("Telefone deve ser preenchido");

        RuleFor(c => c.Endereco)
            .NotNull()
            .NotEmpty()                
            .WithMessage("Endereço deve ser preenchido");
    }
}