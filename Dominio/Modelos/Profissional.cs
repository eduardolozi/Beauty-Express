using System.Diagnostics.CodeAnalysis;

namespace Modelos.Profissional
{
    public class Profissional
    {
        public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        public string Especialidade { get; set; }
    }
}