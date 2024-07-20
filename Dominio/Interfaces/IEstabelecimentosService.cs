using Dominio.Modelos;

namespace Dominio.Interfaces;

public interface IEstabelecimentosService
{
    Task<IEnumerable<Estabelecimento>> ObterTodos();
    Task<Estabelecimento> ObterPorId(int id);
    Task<Estabelecimento> Adicionar(Estabelecimento estabelecimento);
    Task<bool> Atualizar(Estabelecimento estabelecimento);
    Task<bool> Remover(int id);
}