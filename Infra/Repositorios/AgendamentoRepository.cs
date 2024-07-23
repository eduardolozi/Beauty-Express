using Dominio.Interfaces;
using Dominio.Modelos;

namespace Infra.Repositorios;

public class AgendamentoRepository : BaseRepository<Agendamento>, IAgendamentosRepository
{
    public AgendamentoRepository(BeautyContext contexto) : base(contexto)
    {
    }
}