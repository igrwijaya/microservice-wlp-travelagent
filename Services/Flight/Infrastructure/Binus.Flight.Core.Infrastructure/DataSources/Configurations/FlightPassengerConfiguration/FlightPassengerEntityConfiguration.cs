using Binus.Flight.Core.Constant.Entity;
using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Flight.Core.Infrastructure.DataSources.Configurations.FlightPassengerConfiguration;

public class FlightPassengerEntityConfiguration : IEntityTypeConfiguration<FlightPassenger>
{
    public void Configure(EntityTypeBuilder<FlightPassenger> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.HasMany(prop => prop.Tickets)
            .WithOne(prop => prop.FlightPassenger)
            .OnDelete(DeleteBehavior.Cascade);
    }
}