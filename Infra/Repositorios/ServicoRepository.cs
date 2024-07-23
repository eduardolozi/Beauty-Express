using Dominio.Interfaces;
using Dominio.Modelos;

namespace Infra.Repositorios;

public class ServicoRepository : BaseRepository<Servico>, IServicosRepository
{
    public ServicoRepository(BeautyContext contexto) : base(contexto)
    {
    }
}