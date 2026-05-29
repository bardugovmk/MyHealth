using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Persistence.Configurations.Medical;

public class ServiceComponentConfiguration : IEntityTypeConfiguration<ServiceComponent>
{
    public void Configure(EntityTypeBuilder<ServiceComponent> builder)
    {
        builder.ToTable("ServiceComponents");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ParentService)
            .WithMany(x => x.Components)
            .HasForeignKey(x => x.ParentServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ChildService)
            .WithMany()
            .HasForeignKey(x => x.ChildServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}