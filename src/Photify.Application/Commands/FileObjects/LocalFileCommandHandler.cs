using HeyRed.Mime;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Photify.Domain.Entities;
using Photify.Infrastructure;

namespace Photify.Application.Commands.FileObjects
{
    public class LocalFileCommandHandler :
        IRequestHandler<AddLocalFilesCommand, IEnumerable<FileObject>>,
        IRequestHandler<UpdateLocalFilesCommand, IEnumerable<FileObject>>,
        IRequestHandler<DeleteLocalFilesCommand, Unit>
    {
        private readonly IPhotifyContext _dbContext;
        public LocalFileCommandHandler(IPhotifyContext photifyContext)
        {
            _dbContext = photifyContext;
        }
        public async Task<IEnumerable<FileObject>> Handle(AddLocalFilesCommand request, CancellationToken cancellationToken)
        {
            var fileObjects = request.FileInfos.Select(file => new FileObject
            {
                DataSourceId = request.DataSource.Id,
                FilePath = file.FullName,
                FileName = file.Name,
                ContentLength = file.Length,
                ContentType = MimeTypesMap.GetMimeType(file.Extension),
                CreatedAt = file.CreationTimeUtc,
                ModifiedAt = file.LastWriteTimeUtc
            });
            await _dbContext.FileObjects.AddRangeAsync(fileObjects);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return fileObjects;
        }

        public async Task<IEnumerable<FileObject>> Handle(UpdateLocalFilesCommand request, CancellationToken cancellationToken)
        {
            var fullNames = request.FileInfos.Select(x => x.FullName);
            var fileObjects = await _dbContext.FileObjects.Where(x => x.DataSourceId == request.DataSource.Id && fullNames.Contains(x.FilePath)).ToListAsync();
            Parallel.ForEach(fileObjects, item =>
            {
                var file = request.FileInfos.FirstOrDefault(x => x.FullName == item.FilePath);
                if (file != null)
                {
                    item.FileName = file.Name;
                    item.ContentLength = file.Length;
                    item.ContentType = MimeTypesMap.GetMimeType(file.Extension);
                    item.ModifiedAt = file.LastWriteTimeUtc;
                }
            });
            _dbContext.FileObjects.UpdateRange(fileObjects);
            await _dbContext.SaveChangesAsync();
            return fileObjects;
        }

        public async Task<Unit> Handle(DeleteLocalFilesCommand request, CancellationToken cancellationToken)
        {
            var fileObjects = await _dbContext.FileObjects.Where(x => request.FileIds.Contains(x.Id)).ToListAsync();
            _dbContext.FileObjects.RemoveRange(fileObjects);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
