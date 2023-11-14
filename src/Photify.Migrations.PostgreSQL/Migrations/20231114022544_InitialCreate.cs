using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Photify.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "photify");

            migrationBuilder.CreateTable(
                name: "content",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    folder_id = table.Column<int>(type: "integer", nullable: false),
                    blob_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    thumbnail_blob_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    content_length = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "data_source_type",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_source_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "folder",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parnet_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    thumbnail_blob_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    content_length = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    created_by = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "content_claim",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    claim_value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_claim", x => x.id);
                    table.ForeignKey(
                        name: "FK_content_claim_content_content_id",
                        column: x => x.content_id,
                        principalSchema: "photify",
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "content_metadata",
                schema: "photify",
                columns: table => new
                {
                    content_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_metadata", x => x.content_id);
                    table.ForeignKey(
                        name: "FK_content_metadata_content_content_id",
                        column: x => x.content_id,
                        principalSchema: "photify",
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "data_source",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    data = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true),
                    created_by = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    source_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_source", x => x.id);
                    table.ForeignKey(
                        name: "FK_data_source_data_source_type_source_type_id",
                        column: x => x.source_type_id,
                        principalSchema: "photify",
                        principalTable: "data_source_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "content_tag",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content_id = table.Column<int>(type: "integer", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_tag", x => x.id);
                    table.ForeignKey(
                        name: "FK_content_tag_content_content_id",
                        column: x => x.content_id,
                        principalSchema: "photify",
                        principalTable: "content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_content_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalSchema: "photify",
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blob_object",
                schema: "photify",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    data_source_id = table.Column<int>(type: "integer", nullable: false),
                    file_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    file_path = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    content_type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    content_length = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blob_object", x => x.id);
                    table.ForeignKey(
                        name: "FK_blob_object_data_source_data_source_id",
                        column: x => x.data_source_id,
                        principalSchema: "photify",
                        principalTable: "data_source",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blob_object_data_source_id",
                schema: "photify",
                table: "blob_object",
                column: "data_source_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_claim_content_id",
                schema: "photify",
                table: "content_claim",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_tag_content_id",
                schema: "photify",
                table: "content_tag",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_tag_tag_id",
                schema: "photify",
                table: "content_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_data_source_source_type_id",
                schema: "photify",
                table: "data_source",
                column: "source_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blob_object",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "content_claim",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "content_metadata",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "content_tag",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "folder",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "data_source",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "content",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "tag",
                schema: "photify");

            migrationBuilder.DropTable(
                name: "data_source_type",
                schema: "photify");
        }
    }
}
