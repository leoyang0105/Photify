namespace Photify.Application.Interfaces
{
    public enum ThumbnailSize
    {
        Small,
        Medium,
        Large,
    }
    public interface IThumbnailGenerator
    { 
        string[] SupportFormats { get; }
        Task<Stream> GenerateThumbnail(IFileObject fileObject, ThumbnailSize size);
    }
}
