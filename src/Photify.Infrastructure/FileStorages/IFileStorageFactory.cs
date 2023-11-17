using Photify.Domain.Entities;

namespace Photify.Infrastructure.FileStorages
{
    public interface IFileStorageFactory
    {
        IFileStorage GetFileStorage(DataSource dataSource);
    }
}