using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using Modelos.Cliente;
using Modelos.DataHorario;
using Modelos.Pagamento;
using Modelos.PagamentoCartao;
using Modelos.PagamentoPix;
using Modelos.Profissional;

namespace Infra
{
    public class BeautyContext : DbContext
    {
        private readonly string ConexaoBanco = "Server=DESKTOP-HEUDNMR\\B1;Database=BeautyExpress;User ID=sa;Password=sap@123;TrustServerCertificate=True;encrypt=false";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConexaoBanco);
        }

        public DbSet<Agendamento> Agendamentos { get; set;}
        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<DataHorario> DataHorarios { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set;}
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<PagamentoCartao> PagamentosCartao { get; set; }
        public DbSet<PagamentoPix> PagamentosPix { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BeautyContext).Assembly);
        }
        public BeautyContext(DbContextOptions<BeautyContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public BeautyContext() : base() { }
    }
}
