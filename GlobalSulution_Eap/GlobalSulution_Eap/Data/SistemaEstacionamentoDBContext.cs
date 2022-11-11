using GlobalSulution_Eap.Data.Map;
using GlobalSulution_Eap.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSulution_Eap.Data
{
    public class SistemaEstacionamentoDBContext : DbContext
    {

        public SistemaEstacionamentoDBContext(DbContextOptions<SistemaEstacionamentoDBContext> options) : base (options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<VeiculoModel> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
