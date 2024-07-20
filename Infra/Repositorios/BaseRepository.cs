using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class BaseRepository<T> : IRepository<T> where T : EntitiesAbstract, new()
    {
        protected readonly BeautyContext Contexto;
        protected readonly DbSet<T> Db;

        public BaseRepository(BeautyContext contexto)
        {
            Contexto = contexto;
            Db = contexto.Set<T>(); ;
        }

        public async Task Adicionar(T objeto)
        {
            Db.Add(objeto);

            await Contexto.SaveChangesAsync();
        }

        public async Task Atualizar(int id, T objeto)
        {
            Db.Update(objeto);

            await Contexto.SaveChangesAsync();
        }

        public async Task<T> ObterPorId(int id)
        {
            return await Db.FindAsync(id);
        }

        public async Task<List<T>> ObterTodos()
        {
            return await Db.ToListAsync();
        }

        public async Task Remover(int id)
        {
            var excluir = await Db.FindAsync(id);

            Db.Remove(excluir);

            await Contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            Contexto?.Dispose();
        }
    }
}
