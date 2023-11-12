namespace Photify.Infrastructure.Services
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public async Task DeleteAsync(string path)
        {
            File.Delete(path);
            await Task.FromResult(0);
        }
        public async Task<FileInfo> CreateAsync(string path, Stream stream)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var file = new FileInfo(path);
            using var fs = file.Create();
            await stream.CopyToAsync(fs);
            await fs.FlushAsync();
            return file;
        }
        public FileInfo Get(string path)
        {
            return new FileInfo(path);
        }

        public List<FileInfo> GetFilesByDirectory(string path)
        {
            var directory = new DirectoryInfo(path);
            return GetFilesByDirectory(directory);
        }
        public List<FileInfo> GetFilesByDirectory(DirectoryInfo directory)
        {
            var files = new List<FileInfo>();
            files.AddRange(directory.GetFiles());
            var dis = directory.GetDirectories();
            dis.ToList().ForEach(dir =>
            {
                files.AddRange(this.GetFilesByDirectory(dir));
            });
            return files;
        }
    }
}
