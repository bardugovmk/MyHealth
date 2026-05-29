using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Configurations.Medical;

public class MedicalRecordAttachmentConfiguration : IEntityTypeConfiguration<MedicalRecordAttachment>
{
    public void Configure(EntityTypeBuilder<MedicalRecordAttachment> builder)
    {
        builder.ToTable("MedicalRecordAttachments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.FileType)
            .HasMaxLength(50);

        builder.HasOne(x => x.MedicalRecord)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}