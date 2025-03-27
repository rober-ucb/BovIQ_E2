using BovIQ.Domain.Entities;
using BovIQ.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BovIQ.Persistence.Configurations;

internal sealed class HerdConfig : IEntityTypeConfiguration<Herd>
{
    public void Configure(EntityTypeBuilder<Herd> builder)
    {
        //builder.ToTable(TableName.Herd);

        //builder.HasKey(x => x.Id);

        //builder.Property(x => x.Name)
        //    .HasMaxLength(50);

        //ConfigureRelationships(builder);
    }
    //private static void ConfigureRelationships(EntityTypeBuilder<Herd> builder)
    //{
    //    builder.HasMany(x => x.Cows)
    //        .WithOne(x => x.Herd)
    //        .HasForeignKey(x => x.HerdId)
    //        .OnDelete(DeleteBehavior.Restrict);
    //}
}
