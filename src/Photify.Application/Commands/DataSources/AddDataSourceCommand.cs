using MediatR;
using Photify.Domain.Entities;

namespace Photify.Application.Commands.DataSources
{
    public class AddDataSourceCommand : IRequest<DataSource>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public DataSourceType Type { get; set; }
    }
}
