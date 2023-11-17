using Photify.Application.Interfaces;

namespace Photify.FileProcessor
{
    public class ImageThumbnailGenerator : IThumbnailGenerator
    {
        public string[] SupportFormats => throw new NotImplementedException();

        public Task<Stream> GenerateThumbnail(IFileObject fileObject)
        {
            throw new NotImplementedException();
        }
    }
}
