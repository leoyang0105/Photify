using Photify.Domain.Entities;

namespace Photify.Application.Interfaces;

public interface IFileProviderFactory
{
    IFileProvider GetProvider(DataSourceProvider provider);
}
