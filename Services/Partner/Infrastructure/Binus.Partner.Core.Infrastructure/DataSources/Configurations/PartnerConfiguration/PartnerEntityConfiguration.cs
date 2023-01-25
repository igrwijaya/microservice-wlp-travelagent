using Binus.Partner.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Partner.Core.Infrastructure.DataSources.Configurations.PartnerConfiguration;

public class PartnerEntityConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.PartnerAggregate.Partner>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.PartnerAggregate.Partner> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.HasMany(prop => prop.Settings)
            .WithOne(prop => prop.Partner)
            .OnDelete(DeleteBehavior.Cascade);
    }
}