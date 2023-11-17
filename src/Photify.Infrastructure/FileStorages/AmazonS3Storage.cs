using Photify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Infrastructure.FileStorages
{
    public class AmazonS3Storage : IFileStorage
    {
        private readonly DataSource _dataSource;
        public AmazonS3Storage(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public Task CreateAsync(IFileObject file, Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task CreateDirectoryAsync(IFileObject directory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IFileObject file)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IFileObject> GetFileObjectAsync(string fullName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IFileObject>> GetFilesAsync(IFileObject directory)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetStreamAsync(IFileObject file)
        {
            throw new NotImplementedException();
        }
    }
}
