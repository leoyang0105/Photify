using MediatR;
using Photify.Domain.Entities;

namespace Photify.Application.Commands.DataSources
{
    public class UpdateDataSourceDataCommand : IRequest<DataSource>
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public UpdateDataSourceDataCommand(int id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}
