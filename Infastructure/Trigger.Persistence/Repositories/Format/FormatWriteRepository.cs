using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
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
    public class FormatWriteRepository : WriteRepository<Format>, IFormatWriteRepository
    {
        public FormatWriteRepository(TriggerDbContext context) : base(context)
        {
        }
        public bool UploadToS3(string secretAccessKey, string accessKey,string bucketName,List<string> filenames,string folder,IFormFileCollection files)
        {
            AmazonS3Client client = new AmazonS3Client(accessKey, secretAccessKey,Amazon.RegionEndpoint.EUWest2);
            var number = 0;
            foreach (var file in files)
            {
                var postRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = folder +"/"+ filenames[number],
                    InputStream = file.OpenReadStream(),
                };
                PutObjectResponse response = client.PutObjectAsync(postRequest).Result;
                number++;
            }
            return true;
            
        }
    }
}
