using MediatR;

namespace Photify.Application.Commands.FileObjects
{
    public class DeleteLocalFilesCommand : IRequest<Unit>
    {
        public IEnumerable<string> FileIds { get; set; }
        public DeleteLocalFilesCommand(IEnumerable<string> fileIds)
        {
            FileIds = fileIds;
        }
    }
}
