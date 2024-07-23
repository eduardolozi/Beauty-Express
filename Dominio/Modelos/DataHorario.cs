using Dominio.Enumeradores;
using Dominio.Modelos;

namespace Modelos.DataHorario
{
	public class DataHorario : EntitiesAbstract
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }
        public StatusDataHorarioEnum StatusDataHorario { get; set; }
	}
}