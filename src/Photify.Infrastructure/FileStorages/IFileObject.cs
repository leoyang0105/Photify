using Photify.Domain.Entities;

namespace Photify.Infrastructure.FileStorages;

public interface IFileObject
{
    string Name { get; }
    string Format { get; }
    string FullName { get; }
    long Length { get; }
    DateTime CreatedAt { get; }
    DateTime ModifiedAt { get; }
    bool IsDirectory { get; }
}
