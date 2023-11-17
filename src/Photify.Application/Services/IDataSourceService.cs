namespace Photify.Application.Services
{
    public interface IDataSourceService
    {
        Task Indexing(int dataSourceId);
    }
}