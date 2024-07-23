using FluentValidation;
using Modelos.DataHorario;

namespace Dominio.Validadores;

public class DataHorariosValidator : AbstractValidator<DataHorario>
{
    public DataHorariosValidator() 
    {
        RuleFor(x => x.Data)
            .NotEmpty().WithMessage("Data não pode estar vazia.")
            .Must(DataValida)
            .WithMessage("Data deve ser uma data válida.");

        RuleFor(x => x.DataInicio)
            .NotEmpty().WithMessage("Data Inicio não pode estar vazia.")
            .LessThan(x => x.DataFim)
            .WithMessage("Data Inicio deve ser menor que Data Fim.");

        RuleFor(x => x.DataFim)
            .NotEmpty().WithMessage("Data Fim não pode estar vazia.")
            .WithMessage("Data Fim deve ser maior que Data Inicio.");

        RuleFor(x => x.StatusDataHorario)
            .IsInEnum()
            .WithMessage("Status inválido.");
    }

    private bool DataValida(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}