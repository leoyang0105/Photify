using Photify.Application.Queries;
using Photify.Domain.Entities;

namespace Photify.Application.Services
{
    public class DataSourceService : IDataSourceService
    {
        private readonly IDataSourceQueries _dataSourceQueries;
        private readonly ILocalFileService _localLocalFileService;
        public DataSourceService(
            IDataSourceQueries dataSourceQueries,
            ILocalFileService localFileService)
        {
            _dataSourceQueries = dataSourceQueries;
            _localLocalFileService = localFileService;
        }
        public async Task Indexing(int dataSourceId)
        {
            var dataSource = await _dataSourceQueries.GetDataSourceById(dataSourceId);
            if (dataSource == null)
                throw new Exception($"DataSource does not exist {dataSourceId}");
            //if (dataSource.Status == Domain.Entities.DataSourceStatus.Indexing)
            //    throw new Exception($"DataSource is being Indexing {dataSourceId}");

            switch (dataSource.Type)
            {
                case DataSourceType.LocalDisk:
                    {
                        await _localLocalFileService.HandleFolderScan(dataSource);
                    }
                    break;
                case DataSourceType.SMB:
                    break;
                case DataSourceType.AliyunDrive:
                    break;
                case DataSourceType.OneDrive:
                    break;
                case DataSourceType.AliyunOss:
                    break;
                default:
                    break;
            }
        }
    }
}
