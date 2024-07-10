namespace Dominio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> ObterTodos();
        public Task<T> ObterPorId(int id);
        public Task Adicionar(T objeto);
        public Task Atualizar(int id, T objeto);
        public Task Remover(int id);
    }
}
