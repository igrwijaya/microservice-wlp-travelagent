using Binus.Core.Constant.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binus.Core.Infrastructure.DataSources.Configurations.Post
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Binus.Core.Domain.AggregateRoots.Post.Post>
    {
        public void Configure(EntityTypeBuilder<Binus.Core.Domain.AggregateRoots.Post.Post> builder)
        {
            builder.Property(prop => prop.CreatedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.LastModifiedBy)
                .HasMaxLength(CommonEntityConstant.AuditableUserLength);

            builder.Property(prop => prop.Caption)
                .HasMaxLength(PostEntityConstant.ContentLength)
                .IsRequired();

            builder.Property(prop => prop.Image)
                .HasMaxLength(PostEntityConstant.ImageLength);

            builder.HasMany(prop => prop.Comments)
                .WithOne(comment => comment.Post)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}