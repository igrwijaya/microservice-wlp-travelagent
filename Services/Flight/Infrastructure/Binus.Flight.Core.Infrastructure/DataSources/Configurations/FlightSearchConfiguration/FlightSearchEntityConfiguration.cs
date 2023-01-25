using Binus.Flight.Core.Constant.Entity;
using Binus.Flight.Core.Domain.AggregateRoots.FlightSearchAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Flight.Core.Infrastructure.DataSources.Configurations.FlightSearchConfiguration;

public class FlightSearchEntityConfiguration : IEntityTypeConfiguration<FlightSearch>
{
    public void Configure(EntityTypeBuilder<FlightSearch> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}