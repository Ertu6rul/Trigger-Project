using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Domain.Entities;

namespace Trigger.Application.Repositories
{
    public interface IFormatWriteRepository : IWriteRepository<Format>
    {
        public bool UploadToS3(string secretAccessKey, string accessKey, string bucketName, List<string> filenames, string folder, IFormFileCollection files);
    }
}
