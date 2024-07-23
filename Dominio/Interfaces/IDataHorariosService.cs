using Modelos.DataHorario;

namespace Dominio.Interfaces;

public interface IDataHorariosService
{
    Task<IEnumerable<DataHorario>> ObterTodos();
    Task<DataHorario> ObterPorId(int id);
    Task<DataHorario> Adicionar(DataHorario dataHorario);
    Task<bool> Atualizar(DataHorario dataHorario);
    Task<bool> Remover(int id);
}