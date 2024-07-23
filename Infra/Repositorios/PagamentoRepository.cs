using Dominio.Interfaces;
using Modelos.Pagamento;

namespace Infra.Repositorios;

public class PagamentoRepository : BaseRepository<Pagamento>, IPagamentoRepository
{
    public PagamentoRepository(BeautyContext contexto) : base(contexto)
    {
    }
}