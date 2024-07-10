using Dominio.Validadores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ModuloInjecaoDominio
    {
        public static void RegistrarServico(IServiceCollection servicos)
        {
            servicos.AddScoped<PagamentoValidator>();
            servicos.AddScoped<PagamentoCartaoValidator>();

        }
    }
}
