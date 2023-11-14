using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class ContentEntityTypeConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.ToTable("content", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");

        builder.Property(x => x.Name).HasMaxLength(64).HasColumnName("name");
        builder.Property(x => x.Description).HasMaxLength(512).HasColumnName("description");

        builder.Property(x => x.FolderId).HasColumnName("folder_id");
        builder.Property(x => x.BlobId).HasMaxLength(64).HasColumnName("blob_id");
        builder.Property(x => x.ThumbnailBlobId).HasMaxLength(64).HasColumnName("thumbnail_blob_id");

        builder.Property(x => x.ContentLength).HasColumnName("content_length");
        builder.Property(x => x.CreatedBy).HasMaxLength(64).HasColumnName("created_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.DeletedAt).HasColumnName("deleted_at");
        builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");

        builder.HasMany(x => x.ContentClaims).WithOne(x => x.Content).HasForeignKey(x => x.ContentId);
        builder.HasMany(x => x.ContentTags).WithOne(x => x.Content).HasForeignKey(x => x.ContentId);

        builder.HasOne(x => x.Metadata).WithOne(s => s.Content).HasForeignKey<ContentMetadata>(s => s.ContentId);
    }
}
