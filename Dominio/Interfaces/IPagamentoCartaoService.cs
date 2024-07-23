using Modelos.PagamentoCartao;

namespace Dominio.Interfaces;

public interface IPagamentoCartaoService
{
    Task<IEnumerable<PagamentoCartao>> ObterTodos();
    Task<PagamentoCartao> ObterPorId(int id);
    Task<PagamentoCartao> Adicionar(PagamentoCartao pagamentoCartao);
    Task<bool> Atualizar(PagamentoCartao pagamentoCartao);
    Task<bool> Remover(int id);
}