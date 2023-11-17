namespace Photify.Domain.Entities;

public class FileObject : IEntity
{
    public string Id { get; set; }
    public int DataSourceId { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Format { get; set; }
    public long Length { get; set; }
    public bool IsDirectory { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DataSource DataSource { get; set; }
}
