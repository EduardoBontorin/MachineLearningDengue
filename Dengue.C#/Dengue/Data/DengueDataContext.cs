using Dengue.Data.Mappings;
using Dengue.Models;
using Microsoft.EntityFrameworkCore;

namespace Dengue.Data
{
    public class DengueDataContext : DbContext
    {
        public DbSet<Semana> Semanas { get; set; }
        public DbSet<Clima> Climas { get; set; }
        public DbSet<SemanaCLima> ClimasSemana { get; set; }
        public DbSet<ClimaArrumado> ClimasC {  get; set; }

        public DengueDataContext(DbContextOptions<DengueDataContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SemanaMap());
            modelBuilder.ApplyConfiguration(new ClimaMap());
            modelBuilder.ApplyConfiguration(new SemanaClimaMap());
            modelBuilder.ApplyConfiguration(new ClimaArrumadoMap());
        }
    }
}
