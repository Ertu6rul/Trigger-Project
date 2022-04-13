using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var list = new List<byte[]>();
            var folder = "AudioFiles/";
            using (AmazonS3Client client = new AmazonS3Client(accessKey, secretAccessKey, Amazon.RegionEndpoint.EUWest2))
            {
                MemoryStream ms = null;
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = "AudioFiles/" + filename
                };
                using (var response = await client.GetObjectAsync(request))
                {
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        using (ms = new MemoryStream())
                        {
                            await response.ResponseStream.CopyToAsync(ms);
                        }
                    }
                }
                return ms.ToArray();

            }



        }

        
    }
}
