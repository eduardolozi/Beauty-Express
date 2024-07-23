using Dominio.Modelos;

namespace Modelos.PagamentoCartao
{
    public class PagamentoCartao : EntitiesAbstract
    {
        public int Id { get; set; }
        public int NumeroParcelas { get; set; }
    }
}