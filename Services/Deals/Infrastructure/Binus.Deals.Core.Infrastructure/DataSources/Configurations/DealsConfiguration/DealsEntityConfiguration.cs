using Binus.Deals.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Deals.Core.Infrastructure.DataSources.Configurations.DealsConfiguration;

public class DealsEntityConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.DealsAggregate.Deals>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.DealsAggregate.Deals> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.HasMany(prop => prop.DealsPackages)
            .WithOne(item => item.Deals)
            .OnDelete(DeleteBehavior.Cascade);
    }
}