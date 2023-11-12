namespace Photify.Domain.Entities;

public class BlobObject : IEntity
{
    public string Id { get; set; }
    public int DataSourceId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string ContentType { get; set; }
    public long ContentLength { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DataSource DataSource { get; set; }
}
