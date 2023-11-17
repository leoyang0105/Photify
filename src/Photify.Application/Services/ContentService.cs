using Newtonsoft.Json;
using Photify.Application.Model.DataSources;
using Photify.Application.Queries;
using Photify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services
{
    public class ContentService
    {
        private readonly IDataSourceQueries _dataSourceQueries;
        private readonly IFileObjectQueries _fileObjectQueries;
        private readonly IContentQueries _contentQueries;
        public ContentService(
            IDataSourceQueries dataSourceQueries,
            IFileObjectQueries fileObjectQueries,
            IContentQueries contentQueries)
        {
            this._dataSourceQueries = dataSourceQueries;
            this._fileObjectQueries = fileObjectQueries;
            this._contentQueries = contentQueries;
        }
        public async Task SyncFileAsync(int dataSourceId)
        {
            var dataSource = await _dataSourceQueries.GetDataSourceById(dataSourceId);
            if(dataSource.Type == Domain.Entities.DataSourceType.LocalDisk)
            {
                var folderData = JsonConvert.DeserializeObject<DataSourceFolderData>(dataSource.Data);
                var contents = await _contentQueries.GetContents(folderData.TargetFolderId);
                var files = await _fileObjectQueries.GetBySourceId(dataSourceId);
                var addedContents = files.Where(f => !contents.Any(c => c.FileId == f.Id));
                var removedContents = contents.Where(c => !files.Any(f => f.Id == c.FileId));

            }
        }
        public async Task AddContentsAsync(int folderId,IEnumerable<FileObject> fileObjects)
        {

        }
    }
}
