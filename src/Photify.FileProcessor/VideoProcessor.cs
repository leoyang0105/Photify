using Photify.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.FileProcessor;
public class VideoProcessor : IFileProcessor
{
    public string[] SupportFormats => new string[] { };

    public Task Process(IFileObject fileObject)
    {
        throw new NotImplementedException();
    }
}
