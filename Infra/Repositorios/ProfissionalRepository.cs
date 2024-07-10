using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Modelos.Profissional;

namespace Infra.Repositorios
{
    public class ProfissionalRepository : IRepository<Profissional>
    {
        private readonly BeautyContext _contexto;
        public ProfissionalRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Profissional>> ObterTodos()
        {
            return await _contexto.Profissionais.ToListAsync();
        }
        public async Task<Profissional> ObterPorId(int id)
        {
            return await _contexto.Profissionais.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Profissional profissional)
        {
            await _contexto.AddAsync(profissional);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var profissional = await ObterPorId(id);
            _contexto.Remove(profissional);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Profissional profissional)
        {
            var profissionalNoBanco = await ObterPorId(id);
            _contexto.Attach(profissionalNoBanco).CurrentValues.SetValues(profissional);
            await _contexto.SaveChangesAsync();
        }
    }
}