using Photify.Application.Interfaces;

namespace Photify.FileProcessor;

public class FileProcessorFactory : IFileProcessorFactory
{
    private List<IFileProcessor> _fileProcessors;
    private readonly UnsupportedFileProcessor _unsupportedFileProcessor;
    public FileProcessorFactory(
        ImageProcessor imageFileProcessor,
        VideoProcessor videoFileProcessor,
        UnsupportedFileProcessor unsupportedFileProcessor)
    {
        _unsupportedFileProcessor = unsupportedFileProcessor;
        _fileProcessors = new List<IFileProcessor>()
        {
            imageFileProcessor, videoFileProcessor
        };
    }
    public IFileProcessor GetProcessor(string format)
    {
        var processor = _fileProcessors.FirstOrDefault(x => x.SupportFormats.Contains(format.ToLower()));
        return processor ?? _unsupportedFileProcessor;
    }
}
