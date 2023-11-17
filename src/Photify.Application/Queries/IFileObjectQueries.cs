using Photify.Domain.Entities;

namespace Photify.Application.Queries
{
    public interface IFileObjectQueries
    {
        Task<List<FileObject>> GetBySourceId(int sourceId);
    }
}