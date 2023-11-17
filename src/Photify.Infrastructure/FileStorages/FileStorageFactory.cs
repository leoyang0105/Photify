using Photify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.Infrastructure.FileStorages
{
    public class FileStorageFactory : IFileStorageFactory
    {
        public FileStorageFactory() { }
        public IFileStorage GetFileStorage(DataSource dataSource)
        {
            if (dataSource.StorageProviderId == StorageProvider.FileSystem.Id)
            {
                return new FileSystemStorage(dataSource);
            }
            else if (dataSource.StorageProviderId == StorageProvider.AmazonS3.Id)
            {
                return new AmazonS3Storage(dataSource);
            }
            else if (dataSource.StorageProviderId == StorageProvider.AzureBlob.Id)
            {
                return new AzureBlobStorage(dataSource);
            }
            throw new NotSupportedException();
        }
    }
}
