namespace Photify.Application.Interfaces;

public interface IMatadataService
{
    Task<IDictionary<string, string>> GetMatadata(IFileObject fileObject);
}
