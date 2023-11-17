namespace Photify.Domain.Entities;

public class DataSource : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Data { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DataSourceStatus Status { get; set; }
    public int StorageProviderId { get; set; }
}
public enum DataSourceStatus
{
    None = 0,
    Indexing = 1,
    Processing = 2,
    Finished = 3,
    Failed = 4
}