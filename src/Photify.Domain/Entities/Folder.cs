namespace Photify.Domain.Entities;

public class Folder : Entity
{
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ThumbnailBlobId { get; set; }
    public long ContentLength { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
