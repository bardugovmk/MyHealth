using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Scheduling;

namespace MyHealth.Persistence.Configurations.Scheduling;

public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
{
    public void Configure(EntityTypeBuilder<Cabinet> builder)
    {
        builder.ToTable("Cabinets");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Department)
            .HasMaxLength(200);
    }
}