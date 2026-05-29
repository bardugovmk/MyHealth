using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Appointments;

namespace MyHealth.Persistence.Configurations.Appointments;

public class AppointmentServiceConfiguration : IEntityTypeConfiguration<AppointmentService>
{
    public void Configure(EntityTypeBuilder<AppointmentService> builder)
    {
        builder.ToTable("AppointmentServices");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PriceAtMoment)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Notes);

        builder.HasOne(x => x.Appointment)
            .WithMany(x => x.AppointmentServices)
            .HasForeignKey(x => x.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.MedicalService)
            .WithMany(x => x.AppointmentServices)
            .HasForeignKey(x => x.MedicalServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}