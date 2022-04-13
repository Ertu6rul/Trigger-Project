using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trigger.Application.Repositories;
using Trigger.Domain.Entities;
using Trigger.Persistence.Contexts;

namespace Trigger.Persistence.Repositories
{
    public class FormatReadRepository : ReadRepository<Format>, IFormatReadRepository
    {
        public FormatReadRepository(TriggerDbContext context) : base(context)
        {

        }
        public List<string> ReturnFileNames(IFormFileCollection files)
        {
            var nameList = new List<string>();
            foreach (var file in files)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                nameList.Add(randomName);
            }
            return nameList;
        }
        public async Task<byte[]> GetFileFromS3(string filename, string secretAccessKey, string accessKey, string bucketName)
        {
            var extension = filename.Substring(filename.Length - 3);
            var folder = "";
            if (extension == "wav")
            {
                folder = "AudioFiles/";
            }
            using (AmazonS3Client client = new AmazonS3Client(accessKey, secretAccessKey, Amazon.RegionEndpoint.EUWest2))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = folder + filename
                };
                var response = await client.GetObjectAsync(request);

                using (Stream responseStream = response.ResponseStream)
                {
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                        var bytes = ms.ToArray();
                        var download = new FileContentResult(bytes, "application/pdf");
                        download.FileDownloadName = filename;
                        return download.FileContents;
                    }

                }

            }
        }
    }
}
