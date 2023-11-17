using MediatR;
using Photify.Domain.Entities;

namespace Photify.Application.Commands.Contents;

public class UpdateContentsCommand : IRequest<Unit>
{
    public IEnumerable<FileObject> FileObjects { get; set; }
    public UpdateContentsCommand(IEnumerable<FileObject> fileObjects)
    {
        FileObjects = fileObjects;
    }
}
