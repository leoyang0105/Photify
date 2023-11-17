using Photify.Application.Interfaces;
using Photify.Domain.Entities;

namespace Photify.FileProvider;

public class FileProviderFactory : IFileProviderFactory
{
    private readonly LocalFileProvider _localFileProvider;
    private readonly AliyunOssProvider _aliyunOssProvider;
    public FileProviderFactory(
        LocalFileProvider localFileProvider,
        AliyunOssProvider aliyunOssProvider)
    {
        _localFileProvider = localFileProvider;
        _aliyunOssProvider = aliyunOssProvider;
    }

    public IFileProvider GetProvider(DataSourceProvider provider)
    {
        return provider switch
        {
            DataSourceProvider.LocalDisk => _localFileProvider,
            DataSourceProvider.AliyunOss => _aliyunOssProvider,
            _ => null,
        };
    }
}
