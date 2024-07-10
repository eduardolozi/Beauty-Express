using FluentValidation;
using Modelos.Pagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Validadores
{
    public class PagamentoValidator : AbstractValidator<Pagamento>
    {
        public PagamentoValidator ()
        {
            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("ERRO: Pagamento deve ser maior que 0");
        }
    }
}
