namespace Photify.Application.Interfaces
{
    public interface IFileProcessor
    {
        string[] SupportFormats { get; }
        Task Process(IFileObject fileObject);
    }
}
