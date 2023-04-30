using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSolve.Domain.Entities;

namespace NSolve.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.HasMany<Draw>()
            .WithMany(x => x.Users);
    }
}