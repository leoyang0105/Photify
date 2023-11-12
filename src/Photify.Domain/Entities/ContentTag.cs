namespace Photify.Domain.Entities;

public class ContentTag : Entity
{
    public int ContentId { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
    public Content Content { get; set; }
}
