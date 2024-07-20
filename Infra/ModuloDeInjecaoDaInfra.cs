using Dominio.Interfaces;
using Dominio.Modelos;
using Dominio.Service;
using Dominio.Validadores;
using Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Modelos.DataHorario;
using Modelos.Pagamento;
using Modelos.PagamentoCartao;
using Modelos.PagamentoPix;
using Modelos.Profissional;

namespace Infra
{
    public class ModuloDeInjecaoDaInfra
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddDbContext<BeautyContext>();

            servicos.AddScoped<IClienteRepository, ClienteRepository>();
            servicos.AddScoped<IClienteService, ClienteService>();
            servicos.AddScoped<ClienteValidator>();

            servicos.AddScoped<IEstabelecimentosRepository, EstabelecimentoRepository>();
            servicos.AddScoped<IEstabelecimentosService, EstabelecimentosService>();
            servicos.AddScoped<EstabelecimentosValidator>();

            servicos.AddScoped<IProfissionaisRepository, ProfissionalRepository>();
            servicos.AddScoped<IProfissionaisService, ProfissionaisService>();
            servicos.AddScoped<ProfissionaisValidator>();

            servicos.AddScoped<IRepository<Agendamento>, AgendamentoRepository>();            
            servicos.AddScoped<IRepository<DataHorario>, DataHorarioRepository>();            
            servicos.AddScoped<IRepository<Pagamento>, PagamentoRepository>();
            servicos.AddScoped<IRepository<PagamentoCartao>, PagamentoCartaoRepository>();
            servicos.AddScoped<IRepository<PagamentoPix>, PagamentoPixRepository>();
            
            servicos.AddScoped<IRepository<Servico>, ServicoRepository>();
        }

    }
}
