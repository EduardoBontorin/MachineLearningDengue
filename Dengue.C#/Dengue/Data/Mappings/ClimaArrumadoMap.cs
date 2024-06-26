using Dengue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dengue.Data.Mappings
{
    public class ClimaArrumadoMap : IEntityTypeConfiguration<ClimaArrumado>
    {
        public void Configure(EntityTypeBuilder<ClimaArrumado> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
