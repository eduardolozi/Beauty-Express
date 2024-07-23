using Modelos.PagamentoPix;

namespace Dominio.Interfaces;

public interface IPagamentosPixService
{
    Task<IEnumerable<PagamentoPix>> ObterTodos();
    Task<PagamentoPix> ObterPorId(int id);
    Task<PagamentoPix> Adicionar(PagamentoPix pagamentoPix);
    Task<bool> Atualizar(PagamentoPix pagamentoPix);
    Task<bool> Remover(int id);
}