using Photify.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.FileProvider.FileStorages
{
    public interface IFileStorage
    {
        Task CreateAsync(IFileObject file, Stream stream);
        Task CreateDirectoryAsync(IFileObject directory);
        Task<Stream> GetStreamAsync(IFileObject file);
        Task<IFileObject> GetFileObjectAsync(string fullName);
        Task<IEnumerable<IFileObject>> GetFilesAsync(IFileObject directory);
        Task DeleteAsync(IFileObject file);
    }
}
