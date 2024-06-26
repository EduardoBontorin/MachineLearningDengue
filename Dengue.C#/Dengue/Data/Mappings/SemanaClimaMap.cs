using Dengue.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dengue.Data.Mappings
{
    public class SemanaClimaMap : IEntityTypeConfiguration<SemanaCLima>
    {
        public void Configure(EntityTypeBuilder<SemanaCLima> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}