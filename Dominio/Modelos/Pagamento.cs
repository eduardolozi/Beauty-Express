using Dominio.Enumeradores;
using Dominio.Modelos;

namespace Modelos.Pagamento
{
    public class Pagamento : EntitiesAbstract
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; set; }
    }
}