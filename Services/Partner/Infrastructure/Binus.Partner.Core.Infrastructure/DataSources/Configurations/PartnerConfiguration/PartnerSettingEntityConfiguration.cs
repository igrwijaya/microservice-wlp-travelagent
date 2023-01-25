using Binus.Partner.Core.Constant.Entity;
using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Partner.Core.Infrastructure.DataSources.Configurations.PartnerConfiguration;

public class PartnerSettingEntityConfiguration : IEntityTypeConfiguration<PartnerSetting>
{
    public void Configure(EntityTypeBuilder<PartnerSetting> builder)
    {
        builder.Property(prop => prop.CreatedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);

        builder.Property(prop => prop.LastModifiedBy)
            .HasMaxLength(CommonEntityConstant.AuditableUserLength);
    }
}