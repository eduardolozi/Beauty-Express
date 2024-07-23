using Dominio.Interfaces;
using Modelos.PagamentoCartao;

namespace Infra.Repositorios;

public class PagamentoCartaoRepository : BaseRepository<PagamentoCartao>, IPagamentoCartaoRepository
{
    public PagamentoCartaoRepository(BeautyContext contexto) : base(contexto)
    {
    }
}