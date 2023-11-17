using MediatR;
using Photify.Domain.Entities;

namespace Photify.Application.Commands.FileObjects
{
    public class UpdateLocalFilesCommand : IRequest<IEnumerable<FileObject>>
    {
        public DataSource DataSource { get; set; }
        public List<FileInfo> FileInfos { get; set; }
        public UpdateLocalFilesCommand(DataSource dataSource, List<FileInfo> fileInfos)
        {
            DataSource = dataSource;
            FileInfos = fileInfos;
        }
    }
}
