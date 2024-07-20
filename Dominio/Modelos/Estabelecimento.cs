using System.Diagnostics.CodeAnalysis;

namespace Dominio.Modelos
{
    public class Estabelecimento : EntitiesAbstract
    {
        public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        [NotNull] public string Endereco { get; set; }
        [NotNull] public string Telefone { get; set; }
    }
}
