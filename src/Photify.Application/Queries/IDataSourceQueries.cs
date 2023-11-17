using Photify.Domain.Entities;

namespace Photify.Application.Queries
{
    public interface IDataSourceQueries
    {
        Task<List<DataSource>> GetDataSources();
        Task<DataSource> GetDataSourceById(int id);
    }
}