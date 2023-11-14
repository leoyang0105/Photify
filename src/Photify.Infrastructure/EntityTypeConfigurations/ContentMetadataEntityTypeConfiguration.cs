using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class ContentMetadataEntityTypeConfiguration : IEntityTypeConfiguration<ContentMetadata>
{
    public void Configure(EntityTypeBuilder<ContentMetadata> builder)
    {
        builder.ToTable("content_metadata", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.ContentId);
        builder.Property(x => x.ContentId).HasColumnName("content_id");
    }
}
