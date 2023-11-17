using Photify.Domain.Exceptions;

namespace Photify.Domain.Entities;

public class StorageProvider : Enumeration
{
    public static StorageProvider FileSystem = new StorageProvider(1, nameof(FileSystem).ToLowerInvariant());
    public static StorageProvider SMB = new StorageProvider(2, nameof(SMB).ToLowerInvariant());
    public static StorageProvider AzureBlob = new StorageProvider(3, nameof(AzureBlob).ToLowerInvariant());
    public static StorageProvider AmazonS3 = new StorageProvider(4, nameof(AmazonS3).ToLowerInvariant());
    public static StorageProvider AliyunOss = new StorageProvider(5, nameof(AliyunOss).ToLowerInvariant());
    public static StorageProvider OneDrive = new StorageProvider(6, nameof(OneDrive).ToLowerInvariant());
    public StorageProvider(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<StorageProvider> List() =>
        new[] { FileSystem, SMB, AzureBlob, AmazonS3, AliyunOss, OneDrive };

    public static StorageProvider FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new DomainException($"Possible values for StorageProvider: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static StorageProvider From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new DomainException($"Possible values for StorageProvider: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
