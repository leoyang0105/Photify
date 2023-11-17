using Photify.Domain.Entities;

namespace Photify.Infrastructure.FileStorages
{
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
    public class FileSystemStorage : IFileStorage
    {
        private readonly DataSource _dataSource;
        public FileSystemStorage(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task CreateAsync(IFileObject file, Stream stream = null)
        {
            var dir = Path.GetDirectoryName(file.FullName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var fileInfo = new FileInfo(file.FullName);
            using var fs = fileInfo.Create();
            await stream.CopyToAsync(fs);
            await fs.FlushAsync();
        }

        public async Task CreateDirectoryAsync(IFileObject directory)
        {
            var directoryInfo = new DirectoryInfo(directory.FullName);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            await Task.FromResult(0);
        }

        public async Task DeleteAsync(IFileObject file)
        {
            if (file.IsDirectory)
            {
                var directory = new DirectoryInfo(file.FullName);
                if (directory.Exists)
                {
                    directory.Delete();
                }
            }
            else
            {
                var fileInfo = new FileInfo(file.FullName);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
            await Task.FromResult(0);
        }

        public void Dispose() { }

        public async Task<IFileObject> GetFileObjectAsync(string fullName)
        {
            var fileInfo = new FileInfo(fullName);
            if (fileInfo.Exists)
            {
                return new LocalFileObject(fileInfo);
            }
            var directoryInfo = new DirectoryInfo(fullName);
            if (directoryInfo.Exists)
            {
                return new LocalFileObject(directoryInfo);
            }
            return await Task.FromResult(default(LocalFileObject)); ;
        }

        public async Task<IEnumerable<IFileObject>> GetFilesAsync(IFileObject directory)
        {
            var directoryInfo = new DirectoryInfo(directory.FullName);
            if (!directoryInfo.Exists)
                return null;
            var files = directoryInfo.GetAllFiles().Select(f => new LocalFileObject(f));
            return await Task.FromResult(files); ;
        }
        public async Task<Stream> GetStreamAsync(IFileObject file)
        {
            var fileInfo = new FileInfo(file.FullName);
            if (!fileInfo.Exists)
                return null;
            return await Task.FromResult(fileInfo.OpenRead());
        }
    }
}
