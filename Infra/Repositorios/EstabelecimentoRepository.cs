using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class EstabelecimentoRepository : IRepository<Estabelecimento>
    {
        private readonly BeautyContext _contexto;
        public EstabelecimentoRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Estabelecimento>> ObterTodos()
        {
            return await _contexto.Estabelecimentos.ToListAsync();
        }
        public async Task<Estabelecimento> ObterPorId(int id)
        {
            return await _contexto.Estabelecimentos.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Estabelecimento estabelecimento)
        {
            await _contexto.AddAsync(estabelecimento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var estabelecimento = await ObterPorId(id);
            _contexto.Remove(estabelecimento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Estabelecimento estabelecimento)
        {
            var estabelecimentoNoBanco = await ObterPorId(id);
            _contexto.Attach(estabelecimentoNoBanco).CurrentValues.SetValues(estabelecimento);
            await _contexto.SaveChangesAsync();
        }
    }
}
