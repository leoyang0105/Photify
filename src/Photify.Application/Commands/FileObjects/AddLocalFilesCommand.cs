using MediatR;
using Photify.Domain.Entities;

namespace Photify.Application.Commands.FileObjects
{
    public class AddLocalFilesCommand : IRequest<IEnumerable<FileObject>>
    {
        public DataSource DataSource { get; set; }
        public IEnumerable<FileInfo> FileInfos { get; set; }
        public AddLocalFilesCommand(DataSource dataSource, IEnumerable<FileInfo> fileInfos)
        {
            DataSource = dataSource;
            FileInfos = fileInfos;
        }
    }
}
