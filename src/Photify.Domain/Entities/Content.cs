namespace Photify.Domain.Entities;

public class Content : Entity, IAggregateRoot
{
    private ICollection<ContentClaim> _contentClaims;
    private ICollection<ContentTag> _contentTags;
    public int FolderId { get; set; }
    public string BlobId { get; set; }
    public string ThumbnailBlobId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long ContentLength { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ContentMetadata Metadata { get; set; }
    public ICollection<ContentClaim> ContentClaims
    {
        get => _contentClaims ?? (_contentClaims = new List<ContentClaim>());
        private set => _contentClaims = value;
    }
    public ICollection<ContentTag> ContentTags
    {
        get => _contentTags ?? (_contentTags = new List<ContentTag>());
        private set => _contentTags = value;
    }
}
