using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class ServicoRepository : IRepository<Servico>
    {
        private readonly BeautyContext _contexto;
        public ServicoRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Servico>> ObterTodos()
        {
            return await _contexto.Servicos.ToListAsync();
        }
        public async Task<Servico> ObterPorId(int id)
        {
            return await _contexto.Servicos.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Servico servico)
        {
            await _contexto.AddAsync(servico);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var servico = await ObterPorId(id);
            _contexto.Remove(servico);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Servico servico)
        {
            var servicoNoBanco = await ObterPorId(id);
            _contexto.Attach(servicoNoBanco).CurrentValues.SetValues(servico);
            await _contexto.SaveChangesAsync();
        }
    }
}