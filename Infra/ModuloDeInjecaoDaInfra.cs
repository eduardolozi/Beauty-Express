using Dominio.Interfaces;
using Dominio.Service;
using Dominio.Validadores;
using Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public class ModuloDeInjecaoDaInfra
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddDbContext<BeautyContext>();

            servicos.AddScoped<IClienteRepository, ClienteRepository>();
            servicos.AddScoped<IClienteService, ClienteService>();
            servicos.AddScoped<LoginService>();
            servicos.AddScoped<ClienteValidator>();

            servicos.AddScoped<IEstabelecimentosRepository, EstabelecimentoRepository>();
            servicos.AddScoped<IEstabelecimentosService, EstabelecimentosService>();
            servicos.AddScoped<EstabelecimentosValidator>();

            servicos.AddScoped<IProfissionaisRepository, ProfissionalRepository>();
            servicos.AddScoped<IProfissionaisService, ProfissionaisService>();
            servicos.AddScoped<ProfissionaisValidator>();

            servicos.AddScoped<IDataHorariosRepository, DataHorarioRepository>();
            servicos.AddScoped<IDataHorariosService, DataHorariosService>();
            servicos.AddScoped<DataHorariosValidator>();

            servicos.AddScoped<IPagamentoCartaoRepository, PagamentoCartaoRepository>();
            servicos.AddScoped<IPagamentoCartaoService, PagamentoCartaoService>();
            servicos.AddScoped<PagamentoCartaoValidator>();

            servicos.AddScoped<IPagamentosPixRepository, PagamentoPixRepository>();
            servicos.AddScoped<IPagamentosPixService, PagamentosPixService>();
            servicos.AddScoped<PagamentosPixValidator>();

            servicos.AddScoped<IPagamentoRepository, PagamentoRepository>();
            servicos.AddScoped<IPagamentoService, PagamentoService>();
            servicos.AddScoped<PagamentoValidator>();

            servicos.AddScoped<IAgendamentosRepository, AgendamentoRepository>();
            servicos.AddScoped<IAgendamentosService, AgendamentosService>();
            servicos.AddScoped<AgendamentosValidator>();

            servicos.AddScoped<IServicosRepository, ServicoRepository>();
            servicos.AddScoped<IServicosService, ServicosService>();
            servicos.AddScoped<ServicosValidator>();
        }
    }
}