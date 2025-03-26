using BovIQ.Domain.Entities;
using BovIQ.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BovIQ.Persistence.Configurations;

internal sealed class CowConfig : IEntityTypeConfiguration<Cow>
{
    public void Configure(EntityTypeBuilder<Cow> builder)
    {
        builder.ToTable(TableName.Cows);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(x => x.EarTag)
            .HasMaxLength(10);

        builder.Property(x => x.FirstCalvingDate)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.HasIndex(x => x.EarTag)
            .IsUnique();

        ConfigureRelationships(builder);
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Cow> builder)
    {
        builder.HasMany(x => x.MilkSessions)
            .WithOne(x => x.Cow)
            .HasForeignKey(x => x.CowId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
