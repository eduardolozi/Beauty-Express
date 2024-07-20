using Modelos.Cliente;

namespace Dominio.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<Cliente>> ObterTodos();
    Task<Cliente> ObterPorId(int id);
    Task<Cliente> Adicionar(Cliente cliente);
    Task<bool> Atualizar(Cliente cliente);
    Task<bool> Remover(int id);
}