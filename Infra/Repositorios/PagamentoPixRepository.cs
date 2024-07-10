using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Modelos.PagamentoPix;

namespace Infra.Repositorios
{
    public class PagamentoPixRepository : IRepository<PagamentoPix>
    {
        private readonly BeautyContext _contexto;
        public PagamentoPixRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<PagamentoPix>> ObterTodos()
        {
            return await _contexto.PagamentosPix.ToListAsync();
        }
        public async Task<PagamentoPix> ObterPorId(int id)
        {
            return await _contexto.PagamentosPix.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(PagamentoPix pagamentoPix)
        {
            await _contexto.AddAsync(pagamentoPix);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var pagamentoPix = await ObterPorId(id);
            _contexto.Remove(pagamentoPix);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, PagamentoPix pagamentoPix)
        {
            var pagamentoPixNoBanco = await ObterPorId(id);
            _contexto.Attach(pagamentoPixNoBanco).CurrentValues.SetValues(pagamentoPix);
            await _contexto.SaveChangesAsync();
        }
    }
}