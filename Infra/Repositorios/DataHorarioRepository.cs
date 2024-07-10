using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Modelos.DataHorario;

namespace Infra.Repositorios
{
    public class DataHorarioRepository : IRepository<DataHorario>
    {
        private readonly BeautyContext _contexto;
        public DataHorarioRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<DataHorario>> ObterTodos()
        {
            return await _contexto.DataHorarios.ToListAsync();
        }
        public async Task<DataHorario> ObterPorId(int id)
        {
            return await _contexto.DataHorarios.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(DataHorario dataHorario)
        {
            await _contexto.AddAsync(dataHorario);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var dataHorario = await ObterPorId(id);
            _contexto.Remove(dataHorario);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, DataHorario dataHorario)
        {
            var dataHorarioNoBanco = await ObterPorId(id);
            _contexto.Attach(dataHorarioNoBanco).CurrentValues.SetValues(dataHorario);
            await _contexto.SaveChangesAsync();
        }
    }
}
