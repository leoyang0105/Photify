using Microsoft.EntityFrameworkCore;
using Photify.Application.Constants;
using Photify.Domain.Entities;
using Photify.Infrastructure;
using Photify.Infrastructure.Cache;

namespace Photify.Application.Queries
{
    public class FileObjectQueries : IFileObjectQueries
    {
        private readonly ICacheManager _cacheManager;
        private readonly IPhotifyContext _dbContext;
        public FileObjectQueries(
            ICacheManager cacheManager,
            IPhotifyContext photifyContext)
        {
            _cacheManager = cacheManager;
            _dbContext = photifyContext;
        }
        public async Task<List<FileObject>> GetBySourceId(int sourceId)
        {
            return await _cacheManager.GetOrCreateAsync(CacheKeys.GetFileObjectsBySourceId(sourceId),
                () => _dbContext.FileObjects.Where(x => x.DataSourceId == sourceId).ToListAsync());
        }
    }
}
