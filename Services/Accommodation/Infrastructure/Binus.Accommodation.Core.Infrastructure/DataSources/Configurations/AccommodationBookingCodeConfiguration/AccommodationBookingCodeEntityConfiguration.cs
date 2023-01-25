using Binus.Accommodation.Core.Constant.Entity;
using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Accommodation.Core.Infrastructure.DataSources.Configurations.AccommodationBookingCodeConfiguration;

public class AccommodationBookingCodeEntityConfiguration : IEntityTypeConfiguration<AccommodationBookingCode>
{
    public void Configure(EntityTypeBuilder<AccommodationBookingCode> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.HasMany(prop => prop.AccommodationGuests)
            .WithOne(prop => prop.AccommodationBookingCode)
            .OnDelete(DeleteBehavior.Cascade);
    }
}