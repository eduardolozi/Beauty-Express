using Dominio.Interfaces;
using Modelos.PagamentoPix;

namespace Infra.Repositorios;

public class PagamentoPixRepository : BaseRepository<PagamentoPix>, IPagamentosPixRepository
{
    public PagamentoPixRepository(BeautyContext contexto) : base(contexto)
    {
    }
}