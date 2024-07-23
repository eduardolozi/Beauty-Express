using FluentValidation;
using Modelos.PagamentoCartao;

namespace Dominio.Validadores
{
    public class PagamentoCartaoValidator : AbstractValidator<PagamentoCartao>
    {
        public PagamentoCartaoValidator() 
        { 
            RuleFor(x => x.NumeroParcelas)
                .GreaterThanOrEqualTo(1).WithMessage("Erro: Deve ter ao menos uma parcela.");
        }
    }
}
