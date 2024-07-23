using Dominio.Interfaces;
using Modelos.DataHorario;

namespace Infra.Repositorios;

public class DataHorarioRepository : BaseRepository<DataHorario>, IDataHorariosRepository
{
    public DataHorarioRepository(BeautyContext contexto) : base(contexto)
    {
    }
}