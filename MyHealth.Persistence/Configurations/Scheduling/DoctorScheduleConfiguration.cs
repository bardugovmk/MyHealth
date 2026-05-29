using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Scheduling;

namespace MyHealth.Persistence.Configurations.Scheduling;

public class DoctorScheduleConfiguration : IEntityTypeConfiguration<DoctorSchedule>
{
    public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
    {
        builder.ToTable("DoctorSchedules");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Doctor)
            .WithMany(x => x.DoctorSchedules)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Cabinet)
            .WithMany(x => x.DoctorSchedules)
            .HasForeignKey(x => x.CabinetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.DoctorId,
            x.CabinetId,
            x.DayOfWeek,
            x.StartTime,
            x.EndTime
        }).IsUnique();
    }
}