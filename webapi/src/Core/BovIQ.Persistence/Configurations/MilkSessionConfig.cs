using BovIQ.Domain.Entities;
using BovIQ.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BovIQ.Persistence.Configurations;

internal class MilkSessionConfig : IEntityTypeConfiguration<MilkSession>
{
    public void Configure(EntityTypeBuilder<MilkSession> builder)
    {
        builder.ToTable(TableName.MilkSessions);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.MilkVolume)
            .IsRequired()
            .HasPrecision(5, 2)
            .HasComment("Milk volume in liters");

        builder.Property(m => m.MilkingTime)
               .IsRequired()
               .HasConversion<string>()
               .HasComment("Milking time of the day");
    }
}
