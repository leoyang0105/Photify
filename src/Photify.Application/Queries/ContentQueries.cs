using Photify.Infrastructure.Cache;
using Photify.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Photify.Application.Queries
{
    public class ContentQueries : IContentQueries
    {
        private readonly ICacheManager _cacheManager;
        private readonly IPhotifyContext _dbContext;
        public ContentQueries(
            ICacheManager cacheManager,
            IPhotifyContext photifyContext)
        {
            _cacheManager = cacheManager;
            _dbContext = photifyContext;
        }
        public async Task<List<Content>> GetContents(int folderId)
        {
            return await _dbContext.Contents.Where(x => x.FolderId == folderId).ToListAsync();
        }
    }
}
