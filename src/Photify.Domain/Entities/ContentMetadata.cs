namespace Photify.Domain.Entities;

public class ContentMetadata : ValueObject
{
    public int ContentId { get; set; }
    public Content Content { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return new object[] { ContentId };
    }
}
