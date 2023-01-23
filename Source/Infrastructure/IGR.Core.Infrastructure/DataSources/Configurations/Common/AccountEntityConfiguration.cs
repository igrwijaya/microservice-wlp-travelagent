using IGR.Core.Constant.Entity;
using IGR.Core.Domain.AggregateRoots.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGR.Core.Infrastructure.DataSources.Configurations.Common
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(prop => prop.CreatedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.LastModifiedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.Name)
                .HasMaxLength(CommonEntityConstant.NameLength)
                .IsRequired();

            builder.HasMany(prop => prop.Posts)
                .WithOne(post => post.Account)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(prop => prop.Comments)
                .WithOne(comm => comm.Account)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}