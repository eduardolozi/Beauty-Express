using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Modelos.Cliente;
using Modelos.DataHorario;
using Modelos.Pagamento;
using Modelos.PagamentoCartao;
using Modelos.PagamentoPix;
using Modelos.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ModuloDeInjecaoDaInfra
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddDbContext<BeautyContext>();
            servicos.AddScoped<IRepository<Agendamento>, AgendamentoRepository>();
            servicos.AddScoped<IRepository<Cliente>, ClienteRepository>();
            servicos.AddScoped<IRepository<DataHorario>, DataHorarioRepository>();
            servicos.AddScoped<IRepository<Estabelecimento>, EstabelecimentoRepository>();
            servicos.AddScoped<IRepository<Pagamento>, PagamentoRepository>();
            servicos.AddScoped<IRepository<PagamentoCartao>, PagamentoCartaoRepository>();
            servicos.AddScoped<IRepository<PagamentoPix>, PagamentoPixRepository>();
            servicos.AddScoped<IRepository<Profissional>, ProfissionalRepository>();
            servicos.AddScoped<IRepository<Servico>, ServicoRepository>();
        }

    }
}
