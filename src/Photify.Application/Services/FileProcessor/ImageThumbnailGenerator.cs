using Photify.Application.Interfaces;

namespace Photify.FileProcessor
{
    public class ImageThumbnailGenerator : IThumbnailGenerator
    {
        public string[] SupportFormats => new string[] { "jpg","png","jpge"};

        public Task<Stream> GenerateThumbnail(Stream source, ThumbnailSize size)
        {
            throw new NotImplementedException();
        }
    }
}
