using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class FolderEntityTypeConfiguration : IEntityTypeConfiguration<Folder>
{
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
        builder.ToTable("folder", PhotifyDbContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasMaxLength(64).HasColumnName("name");
        builder.Property(x => x.Description).HasMaxLength(512).HasColumnName("description");

        builder.Property(x => x.ThumbnailBlobId).HasMaxLength(64).HasColumnName("thumbnail_blob_id");

        builder.Property(x => x.ContentLength).HasColumnName("content_length");
        builder.Property(x => x.CreatedBy).HasMaxLength(64).HasColumnName("created_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
        builder.Property(x => x.DeletedAt).HasColumnName("deleted_at");
        builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");
    }
}
