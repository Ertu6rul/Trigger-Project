using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Trigger.Domain.Entities;

namespace Trigger.Application.Repositories
{
    public interface IFormatReadRepository : IReadRepository<Format>
    {
        public List<string> ReturnFileNames(IFormFileCollection files);
        public Task<byte[]> GetFileFromS3(string filename, string secretAccessKey, string accessKey, string bucketName);
    }
}
