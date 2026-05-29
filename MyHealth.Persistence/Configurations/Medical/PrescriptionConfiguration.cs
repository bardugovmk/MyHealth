using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Configurations.Medical;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.ToTable("Prescriptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MedicationName)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.Dosage)
            .HasMaxLength(200);

        builder.Property(x => x.Instructions);

        builder.HasOne(x => x.MedicalRecord)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}