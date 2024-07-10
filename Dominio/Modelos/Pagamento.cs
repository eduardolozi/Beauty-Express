using Dominio.Enumeradores;

namespace Modelos.Pagamento
{
    public class Pagamento
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; set; }
    }
}
