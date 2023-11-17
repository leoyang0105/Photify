using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Photify.Application.Commands.Contents;
using Photify.Application.Commands.FileObjects;
using Photify.Application.Constants;
using Photify.Application.Model.DataSources;
using Photify.Application.Queries;
using Photify.Application.Utils;
using Photify.Domain.Entities;
using Photify.Infrastructure;
using Photify.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services
{
    public class LocalFileService : ILocalFileService
    {
        private readonly ILogger _logger;
        private readonly IPhotifyContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IFileObjectQueries _fileObjectQueries;
        private readonly ICacheManager _cacheManager;
        public LocalFileService(
            ILogger<LocalFileService> logger,
            IMediator mediator,
            IPhotifyContext photifyContext,
            IFileObjectQueries fileObjectQueries,
            ICacheManager cacheManager)
        {
            _logger = logger;
            _mediator = mediator;
            _dbContext = photifyContext;
            _fileObjectQueries = fileObjectQueries;
            _cacheManager = cacheManager;
        }
        public async Task Indexing(DataSource dataSource)
        {
            var trans = await _dbContext.BeginTransactionAsync();
            try
            {
                var folderData = JsonConvert.DeserializeObject<DataSourceFolderData>(dataSource.Data);
                var files = FileUtils.GetFilesByDirectory(folderData.SourceFolder);
                var totalCount = files.Count;
                var totalSize = files.Sum(f => f.Length);
                if (folderData.Count != totalCount || folderData.Length != totalSize)
                {
                    var fileObjects = await _fileObjectQueries.GetBySourceId(dataSource.Id);
                    var removedFiles = new List<FileObject>();
                    var changedFiles = new List<FileInfo>();
                    var addedFiles = files.Where(file => !fileObjects.Select(x => x.FilePath).Contains(file.FullName));
                    fileObjects.ForEach(item =>
                    {
                        var file = files.FirstOrDefault(f => f.FullName == item.FilePath);
                        if (file == null)
                        {
                            removedFiles.Add(item);
                        }
                        else if (file.Length != item.ContentLength || file.LastWriteTimeUtc != item.ModifiedAt)
                        {
                            changedFiles.Add(file);
                        }
                    });
                    var addedFileObjects = await _mediator.Send(new AddLocalFilesCommand(dataSource, addedFiles));
                    var updateFileObjects = await _mediator.Send(new UpdateLocalFilesCommand(dataSource, files));
                    await _mediator.Send(new DeleteLocalFilesCommand(removedFiles.Select(x => x.Id)));
                    await _cacheManager.RemoveAsync(CacheKeys.GetFileObjectsBySourceId(dataSource.Id));

                    await _mediator.Send(new AddContentsCommand(folderData.TargetFolderId, addedFileObjects));
                    await _mediator.Send(new UpdateContentsCommand(updateFileObjects));
                    await _mediator.Send(new RemoveContentsCommand(removedFiles.Select(x => x.Id)));

                    folderData.Length = totalSize;
                    folderData.Count = totalCount;
                }

                dataSource.Data = JsonConvert.SerializeObject(folderData);
                dataSource.Status = DataSourceStatus.Finished;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to handle local folder scan.");

            }
        }

        public Task Process(DataSource dataSource)
        {
            throw new NotImplementedException();
        }
    }
}
