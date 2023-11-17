using Photify.Application.Interfaces;

namespace Photify.FileProcessor
{
    public class ImageProcessor : IFileProcessor
    {
        private readonly IThumbnailGeneratorFactory _thumbnailGeneratorFactory;
        private readonly IFileProviderFactory _fileProviderFactory;
        public ImageProcessor(
            IThumbnailGeneratorFactory thumbnailGeneratorFactory,
            IFileProviderFactory fileProviderFactory)
        {
            _thumbnailGeneratorFactory = thumbnailGeneratorFactory;
            _fileProviderFactory = fileProviderFactory;

        }
        public string[] SupportFormats => new string[] { };

        public Task Process(IFileObject fileObject)
        {
            // 1. re-generate thumbnail
            // 2. re-generate metadata 
            throw new NotImplementedException();
        }
        private async Task GenerateThumbnails(IFileObject fileObject)
        { 
        }
        private async Task GenerateThumbnail(IFileObject fileObject,ThumbnailSize size)
        {
            var thumbnailGenerator = _thumbnailGeneratorFactory.GetThumbnailGenerator(fileObject.Format);
            var stream = thumbnailGenerator.GenerateThumbnail(fileObject, size);
        }
    }
}
