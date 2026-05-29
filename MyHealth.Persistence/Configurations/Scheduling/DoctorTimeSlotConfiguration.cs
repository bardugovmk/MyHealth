using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Scheduling;

namespace MyHealth.Persistence.Configurations.Scheduling;

public class DoctorTimeSlotConfiguration : IEntityTypeConfiguration<DoctorTimeSlot>
{
    public void Configure(EntityTypeBuilder<DoctorTimeSlot> builder)
    {
        builder.ToTable("DoctorTimeSlots");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Schedule)
            .WithMany(x => x.TimeSlots)
            .HasForeignKey(x => x.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.ScheduleId,
            x.Date,
            x.StartTime,
            x.EndTime
        }).IsUnique();
    }
}