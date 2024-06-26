using Dengue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dengue.Data.Mappings
{
    public class SemanaMap : IEntityTypeConfiguration<Semana>
    {
        public void Configure(EntityTypeBuilder<Semana> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Sequencial)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Notificacoes)
                .HasMaxLength(30);

            builder.HasIndex(x => x.Sequencial, "IX_Semana_Sequencial");

            


        }
    }
}
