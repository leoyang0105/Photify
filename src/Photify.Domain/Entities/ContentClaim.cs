namespace Photify.Domain.Entities;

public class ContentClaim : Entity
{
    public Content Content { get; set; }
    public int ContentId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
