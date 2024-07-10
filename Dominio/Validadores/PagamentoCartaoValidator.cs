using FluentValidation;
using Modelos.PagamentoCartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
