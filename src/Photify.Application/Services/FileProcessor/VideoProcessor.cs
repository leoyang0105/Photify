using Photify.Application.Interfaces;
using Photify.Domain.Entities;
using Photify.Infrastructure.FileStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photify.FileProcessor;
public class VideoProcessor : IFileProcessor
{
    public string[] SupportFormats => new string[] { };

    public Task Process(DataSource dataSource, IFileObject fileObject)
    {
        throw new NotImplementedException();
    }
}
