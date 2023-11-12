using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tag", PhotifyDbContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");

        builder.Property(x => x.Name).HasMaxLength(64).HasColumnName("name");
        builder.Property(x => x.Description).HasMaxLength(512).HasColumnName("description");
        builder.Property(x => x.CreatedBy).HasMaxLength(64).HasColumnName("created_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

        builder.HasMany(x => x.ContentTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId);
    }
}
