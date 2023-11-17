namespace Photify.Application.Utils
{
    static public class FileUtils
    {
        public static async Task DeleteAsync(string path)
        {
            File.Delete(path);
            await Task.FromResult(0);
        }
        public static async Task<FileInfo> CreateAsync(string path, Stream stream)
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
        public static FileInfo Get(string path)
        {
            return new FileInfo(path);
        }

        public static List<FileInfo> GetFilesByDirectory(string path)
        {
            var directory = new DirectoryInfo(path);
            return GetFilesByDirectory(directory);
        }
        public static List<FileInfo> GetFilesByDirectory(DirectoryInfo directory)
        {
            var files = new List<FileInfo>();
            files.AddRange(directory.GetFiles());
            var dis = directory.GetDirectories();
            dis.ToList().ForEach(dir =>
            {
                files.AddRange(GetFilesByDirectory(dir));
            });
            return files;
        }
    }
}
