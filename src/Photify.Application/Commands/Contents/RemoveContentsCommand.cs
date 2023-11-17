using MediatR;

namespace Photify.Application.Commands.Contents;

public class RemoveContentsCommand : IRequest<Unit>
{
    public IEnumerable<string> FileIds { get; set; }
    public RemoveContentsCommand(IEnumerable<string> fileIds)
    {
        FileIds = fileIds;
    }
}
