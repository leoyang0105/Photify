﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photify.Domain.Entities;


namespace Photify.Infrastructure.EntityTypeConfigurations;

public class FileObjectEntityTypeConfiguration : IEntityTypeConfiguration<FileObject>
{
    public void Configure(EntityTypeBuilder<FileObject> builder)
    {
        builder.ToTable("file_object", PhotifyContext.DEFAULT_SCHEMA);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasMaxLength(64).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(x => x.FileName).HasMaxLength(64).HasColumnName("file_name");
        builder.Property(x => x.FilePath).HasMaxLength(512).HasColumnName("file_path");

        builder.Property(x => x.ContentType).HasMaxLength(64).HasColumnName("content_type");
        builder.Property(x => x.ContentLength).HasColumnName("content_length");
        builder.Property(x => x.CreatedBy).HasMaxLength(64).HasColumnName("created_by");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.DataSourceId).HasColumnName("data_source_id");

        builder.HasOne(x => x.DataSource).WithMany().HasForeignKey(x => x.DataSourceId);
    }
}
