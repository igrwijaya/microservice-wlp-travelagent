using Binus.Flight.Core.Constant.Entity;
using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Flight.Core.Infrastructure.DataSources.Configurations.FlightPassengerConfiguration;

public class FlightTicketEntityConfiguration : IEntityTypeConfiguration<FlightTicket>
{
    public void Configure(EntityTypeBuilder<FlightTicket> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}