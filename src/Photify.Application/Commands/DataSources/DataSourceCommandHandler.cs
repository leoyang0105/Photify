using MassTransit;
using MediatR;
using Photify.Application.Constants;
using Photify.Application.IntegrationEvents.Events;
using Photify.Domain.Entities;
using Photify.Infrastructure;
using Photify.Infrastructure.Cache;

namespace Photify.Application.Commands.DataSources
{
    public class DataSourceCommandHandler :
        IRequestHandler<AddDataSourceCommand, DataSource>,
        IRequestHandler<UpdateDataSourceDataCommand, DataSource>
    {
        private readonly IBus _bus;
        private readonly ICacheManager _cacheManager;
        private readonly IPhotifyContext _dbContext;
        public DataSourceCommandHandler(
            IBus bus,
            ICacheManager cacheManager,
            IPhotifyContext photifyContext)
        {
            _bus = bus;
            _cacheManager = cacheManager;
            _dbContext = photifyContext;
        }
        public async Task<DataSource> Handle(AddDataSourceCommand request, CancellationToken cancellationToken)
        {
            var dataSource = new DataSource()
            {
                Name = request.Name,
                Data = request.Data,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                Type = request.Type,
                Status = DataSourceStatus.None
            };
            await _dbContext.DataSources.AddAsync(dataSource);
            await _dbContext.SaveChangesAsync();
            await _cacheManager.RemoveAsync(CacheKeys.GetAllDataSources);
            await _bus.Publish(new DataSourceIndexingIntegrationEvent(dataSource.Id), cancellationToken);
            return dataSource;
        }

        public async Task<DataSource> Handle(UpdateDataSourceDataCommand request, CancellationToken cancellationToken)
        {
            var dataSource = await _dbContext.DataSources.FindAsync(request.Id);
            dataSource.Data = request.Data;
            _dbContext.DataSources.Update(dataSource);
            await _dbContext.SaveChangesAsync();
            await _cacheManager.RemoveAsync(CacheKeys.GetAllDataSources);
            return dataSource;
        }
    }
}
