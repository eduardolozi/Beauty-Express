using FluentValidation;
using Modelos.PagamentoPix;

namespace Dominio.Validadores;

public class PagamentosPixValidator : AbstractValidator<PagamentoPix>
{
    public PagamentosPixValidator()
    {
        RuleFor(x => x.PrazoVencimento)
            .NotEmpty().WithMessage("Prazo de Vencimento não pode estar vazio.")
            .Must(DataValida)
            .WithMessage("Prazo de Vencimento deve ser uma data válida.");

        RuleFor(x => x.DataPagamento)
            .NotEmpty().WithMessage("Data de Pagamento não pode estar vazia.")
            .Must(DataValida)
            .WithMessage("Data de Pagamento deve ser uma data válida.")
            .LessThanOrEqualTo(x => x.PrazoVencimento)
            .WithMessage("Data de Pagamento deve ser menor ou igual ao Prazo de Vencimento.");
    }

    private bool DataValida(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}