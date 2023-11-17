namespace Photify.Application.Interfaces;

public interface IFileProcessorFactory
{
    IFileProcessor GetProcessor(string format);
}
