using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.People;

namespace MyHealth.Persistence.Configurations.People;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Address)
            .HasMaxLength(300);

        builder.Property(x => x.EmergencyContact)
            .HasMaxLength(200);

        builder.Property(x => x.BloodType)
            .HasMaxLength(50);

        builder.HasOne(x => x.User)
            .WithOne(x => x.Patient)
            .HasForeignKey<Patient>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}