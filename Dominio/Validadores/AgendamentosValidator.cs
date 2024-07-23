using Dominio.Modelos;
using FluentValidation;

namespace Dominio.Validadores;

public class AgendamentosValidator : AbstractValidator<Agendamento>
{
    public AgendamentosValidator()
    {
    }
}