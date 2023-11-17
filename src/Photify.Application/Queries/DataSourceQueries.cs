using Photify.Application.Constants;
using Photify.Domain.Entities;
using Photify.Infrastructure.Cache;
using Photify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Photify.Application.Queries
{
    public class DataSourceQueries : IDataSourceQueries
    {
        private readonly ICacheManager _cacheManager;
        private readonly IPhotifyContext _dbContext;
        public DataSourceQueries(
            ICacheManager cacheManager,
            IPhotifyContext photifyContext)
        {
            _cacheManager = cacheManager;
            _dbContext = photifyContext;
        }
        public async Task<List<DataSource>> GetDataSources()
        {
            return await _cacheManager.GetOrCreateAsync(CacheKeys.GetAllDataSources,
                () => _dbContext.DataSources.ToListAsync());
        }
        public async Task<DataSource> GetDataSourceById(int id)
        {
            var list = await this.GetDataSources();
            return list?.Find(x => x.Id == id);
        }
    }
}
