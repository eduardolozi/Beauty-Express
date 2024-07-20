using Dominio.Interfaces;
using Modelos.Profissional;

namespace Infra.Repositorios
{
    public class ProfissionalRepository : BaseRepository<Profissional>, IProfissionaisRepository
    {        
        public ProfissionalRepository(BeautyContext contexto) : base(contexto)
        {
        }
    }
}