using BovIQ.Domain.Entities;
using BovIQ.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BovIQ.Persistence.Configurations;

internal sealed class BreedConfig : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable(TableName.Breeds);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(150)
            .IsRequired(false);

        ConfigureRelationships(builder);
    }
    private static void ConfigureRelationships(EntityTypeBuilder<Breed> builder)
    {
        builder.HasMany(x => x.Cows)
            .WithOne(x => x.Breed)
            .HasForeignKey(x => x.BreedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
