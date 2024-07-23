using FluentValidation;
using Modelos.Pagamento;


namespace Dominio.Validadores;

public class PagamentoValidator : AbstractValidator<Pagamento>
{
    public PagamentoValidator ()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("Pagamento deve ser maior que 0");
    }
}