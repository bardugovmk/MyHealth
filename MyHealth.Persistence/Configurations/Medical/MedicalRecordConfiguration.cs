using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Configurations.Medical;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.ToTable("MedicalRecords");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Diagnosis);

        builder.Property(x => x.Symptoms);

        builder.Property(x => x.Treatment);

        builder.Property(x => x.Recommendations);

        builder.HasOne(x => x.Patient)
            .WithMany(x => x.MedicalRecords)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AppointmentService)
            .WithMany(x => x.MedicalRecords)
            .HasForeignKey(x => x.AppointmentServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}