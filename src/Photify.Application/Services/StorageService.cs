using Photify.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Application.Services
{
    public class StorageService
    {
        private readonly IFileSystemProvider _fileSystemProvider;
        public StorageService(IFileSystemProvider fileSystemProvider)
        {
            _fileSystemProvider = fileSystemProvider;
        }
        public async Task SyncFiles(string directory)
        {

        }
    }
}
