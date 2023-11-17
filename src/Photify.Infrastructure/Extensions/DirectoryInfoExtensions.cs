namespace System.IO;
public static class DirectoryInfoExtensions
{
    public static IEnumerable<FileInfo> GetAllFiles(this DirectoryInfo directory)
    {
        var files = new List<FileInfo>();
        files.AddRange(directory.GetFiles());
        var dis = directory.GetDirectories();
        dis.ToList().ForEach(dir =>
        {
            files.AddRange(dir.GetAllFiles());
        });
        return files;
    }
}
}
