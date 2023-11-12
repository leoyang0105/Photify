namespace Photify.Domain.Entities;

public class DataSource : Entity
{
    private int _sourceTypeId;
    public string Name { get; set; }
    public string Description { get; set; }
    public string Data { get; set; }
    public string CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DataSourceType SourceType { get; set; }
}
