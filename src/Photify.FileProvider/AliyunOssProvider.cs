using Photify.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.FileProvider
{
    public class AliyunOssProvider : IFileProvider
    {
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
