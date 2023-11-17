namespace Photify.Application.Interfaces
{
    public interface IFileProvider
    {
        Task CreateAsync(IFileObject file, Stream stream);
        Task CreateDirectoryAsync(IFileObject directory);
        Task<Stream> GetStreamAsync(IFileObject file);
        Task<IFileObject> GetFileObjectAsync(string fullName);
        Task<IEnumerable<IFileObject>> GetFilesAsync(IFileObject directory);
        Task DeleteAsync(IFileObject file);
    }
}
