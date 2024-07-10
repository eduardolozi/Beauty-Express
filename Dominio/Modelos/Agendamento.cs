using Modelos.Cliente;
using Modelos.DataHorario;

namespace Dominio.Modelos
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int EstabelecimentoId { get; set; }
        public Servico servico { get; set; }
        public int IdServico { get; set; }
        public Cliente cliente { get; set; }
        public int IdCliente { get; set; }
        public DataHorario DataHorario { get; set; }
    }
}
