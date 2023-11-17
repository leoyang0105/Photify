using Photify.Application.Interfaces;
using Photify.FileProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services.FileProcessor
{
    public class ThumbnailGeneratorFactory : IThumbnailGeneratorFactory
    {
        private readonly DefaultThumbnailGenerator _defaultThumbnailGenerator;
        private readonly List<IThumbnailGenerator> _thumbnailGenerators;
        public ThumbnailGeneratorFactory(
            DefaultThumbnailGenerator defaultThumbnailGenerator,
            ImageThumbnailGenerator imageThumbnailGenerator,
            VideoThumbnailGenerator videoThumbnailGenerator)
        {
            _defaultThumbnailGenerator = defaultThumbnailGenerator;
            _thumbnailGenerators = new List<IThumbnailGenerator>()
            {
                imageThumbnailGenerator, videoThumbnailGenerator
            };
        }

        public IThumbnailGenerator GetThumbnailGenerator(string format)
        {
            var generator = _thumbnailGenerators.FirstOrDefault(x => x.SupportFormats.Contains(format.ToLower()));
            return generator ?? _defaultThumbnailGenerator;
        }
    }
}
