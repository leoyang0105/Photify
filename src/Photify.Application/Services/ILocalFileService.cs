using Photify.Domain.Entities;

namespace Photify.Application.Services
{
    public interface ILocalFileService
    {
        Task Indexing(DataSource dataSource);
        Task Process(DataSource dataSource);
    }
}