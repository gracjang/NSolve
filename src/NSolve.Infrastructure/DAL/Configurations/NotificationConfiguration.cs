using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSolve.Domain.Entities;

namespace NSolve.Infrastructure.DAL.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{

    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .IsRequired();

        builder.Property(x => x.EndTime)
            .IsRequired();

        builder.Property(x => x.GenerateTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne<Draw>()
            .WithMany()
            .HasForeignKey(x => x.DrawId)
            .IsRequired();
    }
}