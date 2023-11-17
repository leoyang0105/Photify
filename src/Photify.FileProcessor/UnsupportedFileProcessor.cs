using Photify.Application.Interfaces;

namespace Photify.FileProcessor;

public class UnsupportedFileProcessor : IFileProcessor
{
    public string[] SupportFormats => new string[] { };
    public Task Process(IFileObject fileObject)
    {
        throw new NotImplementedException();
    }
}
