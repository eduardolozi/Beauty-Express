using Dominio.Enumeradores;
using Modelos.Profissional;
using System.Diagnostics.CodeAnalysis;

namespace Dominio.Modelos
{
    public class Servico
    {
        public int Id { get; set; }
        [NotNull] public string Nome { get; set; }
        public double DuracaoHoras { get; set; }
        public CategoriaServicoEnum Categoria { get; set; }      
        public Profissional Profissional { get; set; }
        public int IdProfissional { get; set; }
    }
}