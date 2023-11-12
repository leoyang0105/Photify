namespace Photify.Domain.Entities;

public class Tag : Entity
{
    private ICollection<ContentTag> _contentTags;
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<ContentTag> ContentTags
    {
        get => _contentTags ?? (_contentTags = new List<ContentTag>());
        private set => _contentTags = value;
    }
}
