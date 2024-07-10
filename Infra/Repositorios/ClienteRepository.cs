using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Modelos.Cliente;

namespace Infra.Repositorios
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly BeautyContext _contexto;
        public ClienteRepository(BeautyContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Cliente>> ObterTodos()
        {
            return await _contexto.Clientes.ToListAsync();
        }
        public async Task<Cliente> ObterPorId(int id)
        {
            return await _contexto.Clientes.FirstAsync(x => x.Id == id);
        }
        public async Task Adicionar(Cliente cliente)
        {
            await _contexto.AddAsync(cliente);
            await _contexto.SaveChangesAsync();
        }
        public async Task Remover(int id)
        {
            var cliente = await ObterPorId(id);
            _contexto.Remove(cliente);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(int id, Cliente cliente)
        {
            var clienteNoBanco = await ObterPorId(id);
            _contexto.Attach(clienteNoBanco).CurrentValues.SetValues(cliente);
            await _contexto.SaveChangesAsync();
        }
    }
}