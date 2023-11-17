using MediatR;
using Photify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Commands.Contents
{
    public class AddContentsCommand : IRequest<IEnumerable<Content>>
    {
        public int FolderId { get; set; }
        public IEnumerable<FileObject> FileObjects { get; set; }
        public AddContentsCommand(int folderId, IEnumerable<FileObject> fileObjects)
        {
            FolderId = folderId;
            FileObjects = fileObjects;
        }
    }
}
