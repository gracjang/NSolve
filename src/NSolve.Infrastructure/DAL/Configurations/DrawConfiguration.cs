using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSolve.Domain.Entities;

namespace NSolve.Infrastructure.DAL.Configurations;

internal sealed class DrawConfiguration : IEntityTypeConfiguration<Draw>
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public void Configure(EntityTypeBuilder<Draw> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.DrawSecrets)
            .IsRequired();

        builder.HasOne(x => x.DrawSecrets)
            .WithOne(x => x.Draw)
            .HasForeignKey<Secrets>(x => x.DrawId)
            .IsRequired();

        builder.HasMany<User>()
            .WithMany();

        var valueComparer = new ValueComparer<Dictionary<string, string>>(
            (c1, c2) => c1!.SequenceEqual(c2!),
            c => c.GetHashCode(),
            c => c.ToDictionary(kv => kv.Key, kv => kv.Value));

        builder.Property(draw => draw.Results)
            .HasConversion(
                results => JsonSerializer.Serialize(results, _jsonSerializerOptions),
                results => JsonSerializer.Deserialize<Dictionary<string, string>>(results, _jsonSerializerOptions)!,
                valueComparer)
            .IsRequired();
    }
}