using Binus.Accommodation.Core.Constant.Entity;
using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Accommodation.Core.Infrastructure.DataSources.Configurations.AccommodationBookingCodeConfiguration;

public class AccommodationGuestConfiguration : IEntityTypeConfiguration<AccommodationGuest>
{
    public void Configure(EntityTypeBuilder<AccommodationGuest> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}