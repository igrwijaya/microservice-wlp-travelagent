using Binus.ActivitiesVendor.Core.Constant.Entity;
using Binus.ActivitiesVendor.Core.Domain.AggregateRoots.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.ActivitiesVendor.Core.Infrastructure.DataSources.Configurations.Post
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(prop => prop.CreatedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.LastModifiedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.Content)
                .HasMaxLength(PostEntityConstant.ContentLength)
                .IsRequired();
        }
    }
}