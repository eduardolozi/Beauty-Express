using Dominio.Interfaces;
using Dominio.Modelos;

namespace Infra.Repositorios;

public class EstabelecimentoRepository : BaseRepository<Estabelecimento>, IEstabelecimentosRepository
{

    public EstabelecimentoRepository(BeautyContext contexto) : base(contexto)
    {

    }
}
