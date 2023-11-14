using Microsoft.EntityFrameworkCore;
using Photify.Domain.Entities;

namespace Photify.Infrastructure
{
    public interface IPhotifyContext : IDbContext
    {
        DbSet<ContentClaim> ContentClaims { get; set; }
        DbSet<ContentMetadata> ContentMetadatas { get; set; }
        DbSet<Content> Contents { get; set; }
        DbSet<ContentTag> ContentTags { get; set; }
        DbSet<DataSource> DataSources { get; set; }
        DbSet<BlobObject> FileObjects { get; set; }
        DbSet<Folder> Folders { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}