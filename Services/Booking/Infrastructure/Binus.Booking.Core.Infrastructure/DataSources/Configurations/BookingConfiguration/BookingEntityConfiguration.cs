using Binus.Booking.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Booking.Core.Infrastructure.DataSources.Configurations.BookingConfiguration;

public class BookingEntityConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.BookingAggregate.Booking>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.BookingAggregate.Booking> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}