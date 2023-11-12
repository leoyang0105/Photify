namespace Photify.Infrastructure.Services;

public interface IFileSystemProvider
{
    Task<FileInfo> CreateAsync(string path, Stream stream);
    Task DeleteAsync(string path);
    FileInfo Get(string path);
    List<FileInfo> GetFilesByDirectory(DirectoryInfo directory);
    List<FileInfo> GetFilesByDirectory(string path);
}