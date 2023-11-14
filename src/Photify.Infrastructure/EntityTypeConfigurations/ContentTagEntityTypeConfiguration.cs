using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class ContentTagEntityTypeConfiguration : IEntityTypeConfiguration<ContentTag>
{
    public void Configure(EntityTypeBuilder<ContentTag> builder)
    {
        builder.ToTable("content_tag", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");
        builder.Property(o => o.ContentId).HasColumnName("content_id");
        builder.Property(o => o.TagId).HasColumnName("tag_id");
    }
}
