using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSolve.Domain.Entities;

namespace NSolve.Infrastructure.DAL.Configurations;

public class SecretsConfiguration : IEntityTypeConfiguration<Secrets>
{

    public void Configure(EntityTypeBuilder<Secrets> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrawId)
            .IsRequired();

        builder.Property(x => x.AdminSecret)
            .IsRequired();

        builder.Property(x => x.JoinerSecret)
            .IsRequired();

        builder.HasOne<Draw>()
            .WithOne()
            .HasForeignKey<Secrets>(x => x.DrawId)
            .IsRequired();
    }
}