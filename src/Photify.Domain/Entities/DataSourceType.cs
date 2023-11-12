using Photify.Domain.Exceptions;

namespace Photify.Domain.Entities;

public class DataSourceType : Enumeration
{
    public static DataSourceType LocalDisk = new DataSourceType(1, nameof(LocalDisk).ToLowerInvariant());
    public static DataSourceType SMB = new DataSourceType(2, nameof(LocalDisk).ToLowerInvariant());
    public static DataSourceType AliyunDrive = new DataSourceType(3, nameof(AliyunDrive).ToLowerInvariant());
    public static DataSourceType AliyunOss = new DataSourceType(4, nameof(AliyunOss).ToLowerInvariant());
    public static DataSourceType OneDrive = new DataSourceType(5, nameof(OneDrive).ToLowerInvariant());
    public DataSourceType(int id, string name) : base(id, name) { }
    public static IEnumerable<DataSourceType> List() =>
        new[] { LocalDisk, SMB, AliyunDrive, AliyunOss, OneDrive };
    public static DataSourceType FromName(string name)
    {
        var type = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (type == null)
        {
            throw new DomainException($"Possible values for DataSourceType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return type;
    }

    public static DataSourceType From(int id)
    {
        var type = List().SingleOrDefault(s => s.Id == id);

        if (type == null)
        {
            throw new DomainException($"Possible values for DataSourceType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return type;
    }
}
