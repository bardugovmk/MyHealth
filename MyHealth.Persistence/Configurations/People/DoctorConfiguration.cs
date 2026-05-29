using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.People;

namespace MyHealth.Persistence.Configurations.People;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.About)
            .HasMaxLength(4000);

        builder.HasOne(x => x.Employee)
            .WithOne(x => x.Doctor)
            .HasForeignKey<Doctor>(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Specialization)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}