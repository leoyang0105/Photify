using Photify.Domain.Entities;
using Photify.Infrastructure.FileStorages;

namespace Photify.Application.Interfaces
{
    public interface IFileProcessor
    {
        string[] SupportFormats { get; }
        Task Process(DataSource dataSource, IFileObject fileObject);
    }
}
