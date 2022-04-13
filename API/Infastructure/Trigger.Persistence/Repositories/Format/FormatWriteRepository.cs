using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
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
        public async Task<bool> UploadToS3(string secretAccessKey, string accessKey,string bucketName,List<string> filenames,string folder, IFormFileCollection files)
        {
            AmazonS3Client client = new AmazonS3Client(accessKey, secretAccessKey,Amazon.RegionEndpoint.USEast1);
            var number = 0;
            foreach (var file in files)
            {
                var postRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    Key = folder +"/"+ filenames[number],
                    InputStream = file.OpenReadStream(),
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(postRequest);
                number++;
            }
            return true;
            
        }
    }
}
