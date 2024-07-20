using Dominio.Interfaces;
using Modelos.Cliente;

namespace Infra.Repositorios;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(BeautyContext contexto) : base(contexto) 
    {
    }
}