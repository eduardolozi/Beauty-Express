using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class AgendamentoRepository : IRepository<Agendamento>
    {
        private readonly BeautyContext _contexto;
        public AgendamentoRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Agendamento>> ObterTodos()
        {
            return await _contexto.Agendamentos.ToListAsync();
        }
        public async Task<Agendamento> ObterPorId(int id)
        {
            return await _contexto.Agendamentos.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Agendamento agendamento)
        {
            await _contexto.AddAsync(agendamento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var agendamento = await ObterPorId(id);
            _contexto.Remove(agendamento);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Agendamento agendamento)
        {
            var servicoNoBanco = await ObterPorId(id);
            _contexto.Attach(servicoNoBanco).CurrentValues.SetValues(agendamento);
            await _contexto.SaveChangesAsync();
        }
    }
}
