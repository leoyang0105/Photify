﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Photify.Infrastructure;

#nullable disable

namespace Photify.Migrations.SQLite.Migrations
{
    [DbContext(typeof(PhotifyContext))]
    partial class PhotifyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Photify.Domain.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("BlobId")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("blob_id");

                    b.Property<long>("ContentLength")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_length");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int>("FolderId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("folder_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("ThumbnailBlobId")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("thumbnail_blob_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("content", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasMaxLength(32)
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<int>("ContentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_id");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("content_claim", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentMetadata", b =>
                {
                    b.Property<int>("ContentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_id");

                    b.HasKey("ContentId");

                    b.ToTable("content_metadata", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("ContentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_id");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("tag_id");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("TagId");

                    b.ToTable("content_tag", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.DataSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<string>("Data")
                        .HasMaxLength(4096)
                        .HasColumnType("TEXT")
                        .HasColumnName("data");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("data_source", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.FileObject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<long>("ContentLength")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_length");

                    b.Property<string>("ContentType")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("content_type");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<int>("DataSourceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("data_source_id");

                    b.Property<string>("FileName")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("file_path");

                    b.HasKey("Id");

                    b.HasIndex("DataSourceId");

                    b.ToTable("file_object", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<long>("ContentLength")
                        .HasColumnType("INTEGER")
                        .HasColumnName("content_length");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("parnet_id");

                    b.Property<string>("ThumbnailBlobId")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("thumbnail_blob_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("folder", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("tag", "photify");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentClaim", b =>
                {
                    b.HasOne("Photify.Domain.Entities.Content", "Content")
                        .WithMany("ContentClaims")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentMetadata", b =>
                {
                    b.HasOne("Photify.Domain.Entities.Content", "Content")
                        .WithOne("Metadata")
                        .HasForeignKey("Photify.Domain.Entities.ContentMetadata", "ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Photify.Domain.Entities.ContentTag", b =>
                {
                    b.HasOne("Photify.Domain.Entities.Content", "Content")
                        .WithMany("ContentTags")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Photify.Domain.Entities.Tag", "Tag")
                        .WithMany("ContentTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Photify.Domain.Entities.FileObject", b =>
                {
                    b.HasOne("Photify.Domain.Entities.DataSource", "DataSource")
                        .WithMany()
                        .HasForeignKey("DataSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataSource");
                });

            modelBuilder.Entity("Photify.Domain.Entities.Content", b =>
                {
                    b.Navigation("ContentClaims");

                    b.Navigation("ContentTags");

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("Photify.Domain.Entities.Tag", b =>
                {
                    b.Navigation("ContentTags");
                });
#pragma warning restore 612, 618
        }
    }
}
