using Photify.Application.Interfaces;
using Photify.Domain.Entities;
using Photify.Infrastructure.FileStorages;

namespace Photify.FileProcessor
{
    public class ImageProcessor : IFileProcessor
    {
        private readonly IThumbnailGeneratorFactory _thumbnailGeneratorFactory;
        private readonly IFileStorageFactory _fileStorageFactory;
        public ImageProcessor(IThumbnailGeneratorFactory thumbnailGeneratorFactory, IFileStorageFactory fileStorageFactory)
        {
            _thumbnailGeneratorFactory = thumbnailGeneratorFactory;
            _fileStorageFactory = fileStorageFactory;
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
        private async Task GenerateThumbnail(IFileObject fileObject, ThumbnailSize size)
        {
            var thumbnailGenerator = _thumbnailGeneratorFactory.GetThumbnailGenerator(fileObject.Format);
            // var stream = thumbnailGenerator.GenerateThumbnail(fileObject, size);
        }

        public Task Process(DataSource dataSource, IFileObject fileObject)
        {
            throw new NotImplementedException();
        }
    }
}
