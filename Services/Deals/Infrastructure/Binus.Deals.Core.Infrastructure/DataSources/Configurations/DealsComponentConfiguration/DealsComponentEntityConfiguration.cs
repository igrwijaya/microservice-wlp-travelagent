using Binus.Deals.Core.Constant.Entity;
using Binus.Deals.Core.Domain.AggregateRoots.DealsComponentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Deals.Core.Infrastructure.DataSources.Configurations.DealsComponentConfiguration;

public class DealsComponentEntityConfiguration : IEntityTypeConfiguration<DealsComponent>
{
    public void Configure(EntityTypeBuilder<DealsComponent> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}