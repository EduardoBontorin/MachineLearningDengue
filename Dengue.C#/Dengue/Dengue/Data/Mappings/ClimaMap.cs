using Dengue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dengue.Data.Mappings
{
    public class ClimaMap : IEntityTypeConfiguration<Clima>
    {
        public void Configure(EntityTypeBuilder<Clima> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
