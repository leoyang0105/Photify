using Photify.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services
{
    public class ThumbnailService : IThumbnailService
    {
        private readonly IFileProvider _fileProvider;
        private readonly IThumbnailGeneratorFactory _thumbnailGeneratorFactory;
        public ThumbnailService(IFileProvider fileProvider, IThumbnailGeneratorFactory thumbnailGeneratorFactory)
        {
            _fileProvider = fileProvider;
            _thumbnailGeneratorFactory = thumbnailGeneratorFactory;

        }
        public async Task<IFileObject> GetOrCreateThumbnail(IFileObject fileObject, ThumbnailSize size)
        {
            var thumbnailGenerator = _thumbnailGeneratorFactory.GetThumbnailGenerator(fileObject.Format);
        }
    }
}
