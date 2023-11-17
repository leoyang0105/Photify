using Photify.Domain.Entities;

namespace Photify.Infrastructure.FileStorages
{
    public interface IFileStorage : IDisposable
    {
        Task CreateAsync(IFileObject file, Stream stream);
        Task CreateDirectoryAsync(IFileObject directory);
        Task<Stream> GetStreamAsync(IFileObject file);
        Task<IFileObject> GetFileObjectAsync(string fullName);
        Task<IEnumerable<IFileObject>> GetFilesAsync(IFileObject directory);
        Task DeleteAsync(IFileObject file);
    }
}
