using Photify.Application.Interfaces;

namespace Photify.Application.Services.FileProcessor
{
    public class DefaultThumbnailGenerator : IThumbnailGenerator
    {
        public string[] SupportFormats => new string[] { };

        public Task<Stream> GenerateThumbnail(Stream source, ThumbnailSize size)
        {
            throw new NotImplementedException();
        }
    }
}
