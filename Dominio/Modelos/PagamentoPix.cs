using Dominio.Modelos;

namespace Modelos.PagamentoPix 
{
    public class PagamentoPix : EntitiesAbstract
    {
        public int Id { get; set; }
        public DateTime PrazoVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
