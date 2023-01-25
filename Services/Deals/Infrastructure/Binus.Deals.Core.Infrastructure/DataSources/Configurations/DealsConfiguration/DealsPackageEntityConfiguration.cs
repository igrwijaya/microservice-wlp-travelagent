using Binus.Deals.Core.Constant.Entity;
using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Deals.Core.Infrastructure.DataSources.Configurations.DealsConfiguration;

public class DealsPackageEntityConfiguration : IEntityTypeConfiguration<DealsPackage>
{
    public void Configure(EntityTypeBuilder<DealsPackage> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}