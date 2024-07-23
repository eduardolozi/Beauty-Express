using Modelos.Pagamento;

namespace Dominio.Interfaces;

public interface IPagamentoService
{
    Task<IEnumerable<Pagamento>> ObterTodos();
    Task<Pagamento> ObterPorId(int id);
    Task<Pagamento> Adicionar(Pagamento pagamento);
    Task<bool> Atualizar(Pagamento pagamento);
    Task<bool> Remover(int id);
}