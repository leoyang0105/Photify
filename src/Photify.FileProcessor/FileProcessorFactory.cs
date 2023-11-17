using Photify.Application.Interfaces;

namespace Photify.FileProcessor;

public class FileProcessorFactory : IFileProcessorFactory
{
    private List<IFileProcessor> _fileProcessors = new List<IFileProcessor>();
    private readonly UnsupportedFileProcessor _unsupportedFileProcessor;
    public FileProcessorFactory(
        ImageProcessor imageFileProcessor,
        VideoProcessor videoFileProcessor,
        UnsupportedFileProcessor unsupportedFileProcessor)
    {
        _fileProcessors.Add(imageFileProcessor);
        _fileProcessors.Add(videoFileProcessor);
        _unsupportedFileProcessor = unsupportedFileProcessor;
    }
    public IFileProcessor GetProcessor(string format)
    {
        var processor = _fileProcessors.FirstOrDefault(x => x.SupportFormats.Contains(format.ToLower()));
        if (processor == null)
        {
            return _unsupportedFileProcessor;
        }
        return processor;
    }
}
