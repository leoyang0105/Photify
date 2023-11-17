using Photify.Infrastructure.FileStorages;

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
        Task<Stream> GenerateThumbnail(Stream source, ThumbnailSize size);
    }
}
