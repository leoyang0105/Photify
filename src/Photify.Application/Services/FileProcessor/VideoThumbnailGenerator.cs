using Photify.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services.FileProcessor
{
    public class VideoThumbnailGenerator : IThumbnailGenerator
    {
        public string[] SupportFormats => throw new NotImplementedException();

        public Task<Stream> GenerateThumbnail(Stream source, ThumbnailSize size)
        {
            throw new NotImplementedException();
        }
    }
}
