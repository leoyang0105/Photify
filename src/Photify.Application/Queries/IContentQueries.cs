using Photify.Domain.Entities;

namespace Photify.Application.Queries
{
    public interface IContentQueries
    {
        Task<List<Content>> GetContents(int folderId);
    }
}