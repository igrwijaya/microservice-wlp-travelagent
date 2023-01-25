using Binus.Transaction.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Transaction.Core.Infrastructure.DataSources.Configurations.TransactionConfiguration;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.TransactionAggregate.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.TransactionAggregate.Transaction> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}