using MediatR;
using Microsoft.EntityFrameworkCore;
using Photify.Domain.Entities;
using Photify.Infrastructure.EntityTypeConfigurations;

namespace Photify.Infrastructure
{
    public class PhotifyContext : DbContextBase<PhotifyContext>, IPhotifyContext
    {
        public PhotifyContext(DbContextOptions<PhotifyContext> options, IMediator mediator = null) : base(options, mediator) { }

        public static string DEFAULT_SCHEMA = "photify";
        public string Schema => DEFAULT_SCHEMA;
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentClaim> ContentClaims { get; set; }
        public DbSet<ContentMetadata> ContentMetadatas { get; set; }
        public DbSet<ContentTag> ContentTags { get; set; }
        public DbSet<FileObject> FileObjects { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DataSource> DataSources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileObjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContentClaimEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContentMetadataEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContentTagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FolderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DataSourceEntityTypeConfiguration());
        }
    }
}
