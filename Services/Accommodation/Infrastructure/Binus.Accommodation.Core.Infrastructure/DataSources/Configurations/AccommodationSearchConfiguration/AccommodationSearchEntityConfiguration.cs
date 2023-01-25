using Binus.Accommodation.Core.Constant.Entity;
using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationSearchAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Accommodation.Core.Infrastructure.DataSources.Configurations.AccommodationSearchConfiguration;

public class AccommodationSearchEntityConfiguration : IEntityTypeConfiguration<AccommodationSearch>
{
    public void Configure(EntityTypeBuilder<AccommodationSearch> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}