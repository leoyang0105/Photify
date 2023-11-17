using Photify.Application.Interfaces;

namespace Photify.FileProvider.Models;

public class LocalFileObject : IFileObject
{
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Format { get; set; }
    public long Length { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDirectory { get; set; }
    public LocalFileObject(FileInfo file)
    {
        this.Name = file.Name;
        this.FullName = file.FullName;
        this.Length = file.Length;
        this.CreatedAt = file.CreationTimeUtc;
        this.ModifiedAt = file.LastWriteTimeUtc;
        this.IsDirectory = false;
    }
    public LocalFileObject(DirectoryInfo directory)
    {
        this.Name = directory.Name;
        this.FullName = directory.FullName;
        this.CreatedAt = directory.CreationTimeUtc;
        this.ModifiedAt = directory.LastWriteTimeUtc;
        this.IsDirectory = true;
        this.Length = directory.GetAllFiles().Sum(f => f.Length);
    }
}
