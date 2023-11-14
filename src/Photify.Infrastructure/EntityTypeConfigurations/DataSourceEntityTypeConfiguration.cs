using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;

namespace Photify.Infrastructure.EntityTypeConfigurations;

public class DataSourceEntityTypeConfiguration : IEntityTypeConfiguration<DataSource>
{
    public void Configure(EntityTypeBuilder<DataSource> builder)
    {
        builder.ToTable("data_source", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);
        builder.Property(o => o.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasMaxLength(64).HasColumnName("name");
        builder.Property(x => x.Description).HasMaxLength(512).HasColumnName("description");
        builder.Property(x => x.Data).HasMaxLength(4096).HasColumnName("data");

        builder.Property(x => x.CreatedBy).HasMaxLength(64).HasColumnName("created_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.DeletedAt).HasColumnName("deleted_at");
        builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");

        builder.Property<int>("_sourceTypeId").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("source_type_id").IsRequired();
        builder.HasOne(o => o.SourceType).WithMany().HasForeignKey("_sourceTypeId");
    }
}
