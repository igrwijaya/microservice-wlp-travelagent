using Binus.Customer.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Customer.Core.Infrastructure.DataSources.Configurations.CustomerConfiguration;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.CustomerAggregate.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.CustomerAggregate.Customer> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}