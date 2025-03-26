﻿using BovIQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BovIQ.Persistence.Configurations;

internal sealed class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(50);

        builder.Property(x => x.LastName).HasMaxLength(50);

        builder.Property(x => x.CreateAtUtc)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdateAtUtc)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

        ConfigureRelationships(builder);
    }
    private static void ConfigureRelationships(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany(x => x.Herds)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
