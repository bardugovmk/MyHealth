using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Configurations.Medical;

public class MedicalServiceConfiguration : IEntityTypeConfiguration<MedicalService>
{
    public void Configure(EntityTypeBuilder<MedicalService> builder)
    {
        builder.ToTable("MedicalServices");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.BasePrice)
            .HasColumnType("decimal(18,2)");
    }
}